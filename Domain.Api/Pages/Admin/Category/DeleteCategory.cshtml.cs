using Domain.Api.Pages.Admin.Shared;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.Category
{
    public class DeleteCategoryModel : BaseDeleteModel<Persistance.Entities.Entities.Category>
    {
        public DeleteCategoryModel(ICategoryService service) : base(service)
        {
        }
    }
}
