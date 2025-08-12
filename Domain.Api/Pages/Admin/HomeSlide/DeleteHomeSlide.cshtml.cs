using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.HomeSlide
{
    public class DeleteHomeSlideModel : BaseDeleteModel<Persistance.Entities.Entities.HomeSlide>
    {
        public DeleteHomeSlideModel(IHomeSlideService service) : base(service)
        {
        }
    }
}
