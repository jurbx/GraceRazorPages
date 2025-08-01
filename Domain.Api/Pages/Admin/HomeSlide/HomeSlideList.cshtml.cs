using Domain.Persistance.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.HomeSlide
{
    public class HomeSlideListModel : PageModel
    {
        private readonly IHomeSlideRepository homeSlideRepository;

        public IEnumerable<Persistance.Entities.Entities.HomeSlide> HomeSlides { get; set; }
        public HomeSlideListModel(IHomeSlideRepository homeSlideRepository) 
        {
            this.homeSlideRepository = homeSlideRepository;
        }

        public async Task OnGetAsync()
        {
            HomeSlides = await homeSlideRepository.GetAllAsync();
        }
    }
}
