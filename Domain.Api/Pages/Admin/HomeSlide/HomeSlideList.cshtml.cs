using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.HomeSlide
{
    public class HomeSlideListModel : BaseListModel<Persistance.Entities.Entities.HomeSlide>
    {
        public HomeSlideListModel(IHomeSlideService service) : base(service)
        {
            IncludedProperties = new List<string>
            {
                nameof(Persistance.Entities.Entities.HomeSlide.Title),
                nameof(Persistance.Entities.Entities.HomeSlide.Description),
            };
        }
    }
}
