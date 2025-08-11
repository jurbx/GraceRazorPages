using Domain.Api.Pages.Admin.Shared;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.Category
{
    public class CategoryList : BaseListModel<Persistance.Entities.Entities.Category>
    {
        public CategoryList(ICategoryService service) : base(service)
        {
            IncludedProperties = new List<string>
            {
                nameof(Persistance.Entities.Entities.Category.CategoryName),
                nameof(Persistance.Entities.Entities.Category.CategoryImage),
            };
        }
    }
}
