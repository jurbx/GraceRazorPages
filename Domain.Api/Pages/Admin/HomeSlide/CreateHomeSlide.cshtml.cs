using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.HomeSlide
{
    public class CreateHomeSlideModel : BaseCreateImgModel<Persistance.Entities.Entities.HomeSlide>
    {
        public CreateHomeSlideModel(
            IHomeSlideService service, 
            IS3BucketService s3BucketService,
            IImageService imageService) 
            : base(service, s3BucketService, imageService)
        {
        }
    }
}
