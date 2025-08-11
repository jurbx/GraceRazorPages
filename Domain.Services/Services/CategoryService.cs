using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;

namespace Domain.Services.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
