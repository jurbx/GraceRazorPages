using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared.Model
{
    public class BaseCreateImgModel<IEntity> : PageModel where IEntity : ImgEntity
    {
        protected readonly IService<IEntity> service;
        protected readonly IS3BucketService s3BucketService;


        public required object _Entity = Activator.CreateInstance(typeof(IEntity));
        public IEnumerable<string> ExcludedProperties { get; set; } = new List<string>
        {
            nameof(Entity.Id),
            nameof(Entity.CreatedOn),
            nameof(Entity.UpdatedOn),
        };

        public BaseCreateImgModel(IService<IEntity> service, IS3BucketService s3BucketService)
        {
            this.service = service;
            this.s3BucketService = s3BucketService;
        }

        public async Task OnGetAsync(Guid? id)
        {
            if (id != null)
            {
                _Entity = await service.GetByIdAsync(id);
            }
        }

        public async Task<IActionResult> OnPostAsync(IEntity entity, IFormFile? formFile)
        {
            var dbEntity = await service.GetByIdAsync(entity.Id);
            var newFileName = $"{typeof(IEntity).Name}/{formFile?.FileName}";

            if (dbEntity == null)
            {
                if (formFile != null)
                {
                    entity.ImgName = await s3BucketService.UploadFileAsync(formFile, newFileName);
                }
                await service.CreateAsync(entity);
            }
            else
            {
                if (formFile != null && formFile.FileName != dbEntity.ImgName)
                {
                    if (dbEntity.ImgName != null)
                    {
                        await s3BucketService.DeleteFileAsync(dbEntity.ImgName);
                    }

                    entity.ImgName = await s3BucketService.UploadFileAsync(formFile, newFileName);
                }

                await service.UpdateAsync(entity);
            }

            return Redirect($"/Admin/{entity.GetType().Name}/{entity.GetType().Name}List");
        }
    }
}
