using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;

namespace Domain.Services.Services
{
    public class HomeSlideService : Service<HomeSlide>, IHomeSlideService
    {
        public HomeSlideService(IHomeSlideRepository homeSlideRepository) : base(homeSlideRepository)
        {
        }
    }
}
