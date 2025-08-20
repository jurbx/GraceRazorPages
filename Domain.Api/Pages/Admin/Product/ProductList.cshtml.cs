using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.Product
{
    public class ProductListModel : BaseListModel<Persistance.Entities.Entities.Product>
    {
        public ProductListModel(IProductService service) : base(service)
        {
            IncludedProperties = new List<string>
            {
                nameof(Persistance.Entities.Entities.Product.Name),
                nameof(Persistance.Entities.Entities.Product.Category)
            };
        }
    }
}
