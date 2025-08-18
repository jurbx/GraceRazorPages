using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHomeSlideService homeSlideService;
        private readonly IImageService imageService;

        public Dictionary<HomeSlide, Image?> HomeSlides { get; set; } = new Dictionary<HomeSlide, Image?>();

        public string StorageUrl { get; set; } = "grace-furniture.s3-accelerate.amazonaws.com";
        public IndexModel(IHomeSlideService homeSlideService, IImageService imageService)
        {
            this.homeSlideService = homeSlideService;
            this.imageService = imageService;
        }
        public async Task OnGetAsync()
        {
            var homeSlides = await homeSlideService.GetAllAsync();

            foreach (var slide in homeSlides)
            {
                var image = (await imageService.GetByEntityIdAsync(slide.Id)).FirstOrDefault();
                HomeSlides[slide] = image;
            }

        }
    }
}
