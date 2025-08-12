using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.Category
{
    public class DeleteCategoryModel : BaseDeleteImgModel<Persistance.Entities.Entities.Category>
    {
        public DeleteCategoryModel(ICategoryService service, IS3BucketService s3BucketService) : base(service, s3BucketService)
        {
        }
    }
}
