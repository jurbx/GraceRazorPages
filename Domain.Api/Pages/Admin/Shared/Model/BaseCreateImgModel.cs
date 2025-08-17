using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared.Model
{
    public class BaseCreateImgModel<IEntity> : PageModel where IEntity : Entity
    {
        protected readonly IService<IEntity> service;
        protected readonly IS3BucketService s3BucketService;
        private readonly IImageService imageService;

        public object _Entity = Activator.CreateInstance(typeof(IEntity));
        public IEnumerable<Image> Images { get; set; } = Enumerable.Empty<Image>();
        public IEnumerable<string> ExcludedProperties { get; set; } = new List<string>
        {
            nameof(Entity.Id),
            nameof(Entity.CreatedOn),
            nameof(Entity.UpdatedOn),
        };

        public BaseCreateImgModel(
            IService<IEntity> service, 
            IS3BucketService s3BucketService, 
            IImageService imageService)
        {
            this.service = service;
            this.s3BucketService = s3BucketService;
            this.imageService = imageService;
        }

        public async Task OnGetAsync(Guid? id)
        {
            if (id != null)
            {
                _Entity = await service.GetByIdAsync(id);
                Images = await imageService.GetByEntityIdAsync(id);
            }
        }

        public async Task<IActionResult> OnPostAsync(IEntity entity)
        {

            var dbEntity = await service.GetByIdAsync(entity.Id);


            if (dbEntity == null)
            {
                await service.CreateAsync(entity);
            }
            else
            {
                await service.UpdateAsync(entity);
            }

            await SaveImages(entity.Id);

            return Redirect($"/Admin/{entity.GetType().Name}/{entity.GetType().Name}List");
        }

        private async Task SaveImages(Guid? entityId)
        {
            var files = Request.Form.Files;
            var images = await imageService.GetByEntityIdAsync(entityId);

            foreach (var file in files)
            {
                var newFileName = $"{typeof(IEntity).Name}/{file?.FileName}";
                if (!images.Any(img => img.ImagePath == newFileName))
                {
                    await s3BucketService.UploadFileAsync(file, newFileName);
                    await imageService.CreateAsync(new Image 
                    { 
                        EntityId = entityId,
                        ImagePath = newFileName
                    });
                }
            }
        }
    }
}
