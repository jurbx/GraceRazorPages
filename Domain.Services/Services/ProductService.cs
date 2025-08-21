using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;

namespace Domain.Services.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IColorService colorService;

        public ProductService(
            IProductRepository repository,
            IColorService colorService) : base(repository)
        {
            this.colorService = colorService;
        }

        public override async Task DeleteAsync(Guid? id)
        {
            var colors = await colorService.GetByProductIdAsync(id);

            foreach (var color in colors)
            {
                await colorService.DeleteAsync(color.Id);
            }

            await base.DeleteAsync(id);
        }
    }
}
