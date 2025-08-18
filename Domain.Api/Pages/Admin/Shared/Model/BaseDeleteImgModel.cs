using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared.Model
{
    public class BaseDeleteImgModel<IEntity> : PageModel where IEntity : Entity
    {
        private readonly IService<IEntity> service;
        private readonly IS3BucketService s3BucketService;
        private readonly IImageService imageService;

        public BaseDeleteImgModel(
            IService<IEntity> service, 
            IS3BucketService s3BucketService,
            IImageService imageService)
        {
            this.service = service;
            this.s3BucketService = s3BucketService;
            this.imageService = imageService;
        }

        public virtual async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var entity = await service.GetByIdAsync(id);

            if (entity != null)
            {
                var images = await imageService.GetByEntityIdAsync(entity.Id);
                foreach (var image in images)
                {
                    await s3BucketService.DeleteFileAsync(image.ImagePath);
                    await imageService.DeleteAsync(image.Id);
                }
                await service.DeleteAsync(id);
            }

            return Redirect($"/Admin/{typeof(IEntity).Name}/{typeof(IEntity).Name}List");
        }
    }
}
