using Domain.Api.Pages.Admin.Shared.Model;
using Domain.Services.Contracts.Services;

namespace Domain.Api.Pages.Admin.Product
{
    public class CreateProductModel : BaseCreateImgModel<Persistance.Entities.Entities.Product>
    {
        private readonly ICategoryService categoryService;

        public IEnumerable<Persistance.Entities.Entities.Category> Categories { get; set; } = Enumerable.Empty<Persistance.Entities.Entities.Category>();

        public CreateProductModel(
            IProductService service, 
            IS3BucketService s3BucketService, 
            IImageService imageService,
            ICategoryService categoryService) : base(service, s3BucketService, imageService)
        {
            this.categoryService = categoryService;

            ExcludedProperties = ExcludedProperties.Append(nameof(Persistance.Entities.Entities.Product.Colors));
        }

        public override async Task OnGetAsync(Guid? id)
        {
            Categories = await categoryService.GetAllAsync();
            await base.OnGetAsync(id);
        }
    }
}
