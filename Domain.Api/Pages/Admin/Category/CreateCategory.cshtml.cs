using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.Category
{
    public class CreateCategoryModel : BaseCreateImgModel<Persistance.Entities.Entities.Category>
    {
        public CreateCategoryModel(
            ICategoryService service, 
            IS3BucketService s3BucketService,
            IImageService imageService)
            : base(service, s3BucketService, imageService)
        {
        }
    }
}
