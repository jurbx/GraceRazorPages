using Domain.Api.Pages.Admin.Shared;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.HomeSlide
{
    public class CreateHomeSlideModel : BaseCreateModel<Persistance.Entities.Entities.HomeSlide>
    {
        public CreateHomeSlideModel(IHomeSlideService service) : base(service)
        {
        }
    }
}
