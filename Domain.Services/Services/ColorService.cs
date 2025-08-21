using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;

namespace Domain.Services.Services
{
    public class ColorService : Service<Color>, IColorService
    {
        private readonly IColorRepository colorRepository;
        private readonly IImageService imageService;

        public ColorService(
            IColorRepository colorRepository,
            IImageService imageService) : base(colorRepository)
        {
            this.colorRepository = colorRepository;
            this.imageService = imageService;
        }

        public async Task<IEnumerable<Color>> GetByProductIdAsync(Guid? productId)
        {
            return await colorRepository.GetByProductIdAsync(productId);
        }

        public override async Task DeleteAsync(Guid? id)
        {
            var images = await imageService.GetByEntityIdAsync(id);
            foreach (var image in images)
            {
                await imageService.DeleteAsync(image.Id);
            }

            await base.DeleteAsync(id);
        }
    }
}
