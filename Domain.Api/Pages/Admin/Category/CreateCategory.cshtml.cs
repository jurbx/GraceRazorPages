using Domain.Api.Pages.Admin.Shared;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.Category
{
    public class CreateCategoryModel : BaseCreateModel<Persistance.Entities.Entities.Category>
    {
        public CreateCategoryModel(ICategoryService service) : base(service)
        {
        }
    }
}
