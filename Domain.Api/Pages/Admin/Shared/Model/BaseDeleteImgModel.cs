using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared.Model
{
    public class BaseDeleteImgModel<IEntity> : PageModel where IEntity : ImgEntity
    {
        private readonly IService<IEntity> service;
        private readonly IS3BucketService s3BucketService;

        public BaseDeleteImgModel(IService<IEntity> service, IS3BucketService s3BucketService)
        {
            this.service = service;
            this.s3BucketService = s3BucketService;
        }

        public virtual async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var entity = await service.GetByIdAsync(id);

            if (entity != null)
            {
                if (entity.ImgName != null)
                {
                    await s3BucketService.DeleteFileAsync(entity.ImgName);
                }
                await service.DeleteAsync(id);
            }

            return Redirect($"/Admin/{typeof(IEntity).Name}/{typeof(IEntity).Name}List");
        }
    }
}
