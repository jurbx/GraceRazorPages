using Domain.Generics.Services;
using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Entities.Entities;
using Domain.Services.Contracts.Services;

namespace Domain.Services.Services
{
    public class ImageService : Service<Image>, IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository repository) : base(repository)
        {
            this.imageRepository = repository;
        }

        public async Task<IEnumerable<Image>> GetByEntityIdAsync(Guid? entityId)
        {
            return await imageRepository.GetByEntityId(entityId);
        }
    }
}
