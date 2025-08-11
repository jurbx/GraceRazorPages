using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared
{
    public class BaseListModel<IEntity> : PageModel where IEntity : Entity
    {
        private readonly IService<IEntity> service;
        public IEnumerable<object> Entities { get; set; }
        public required IEnumerable<string> IncludedProperties { get; set; } = Enumerable.Empty<string>();

        public BaseListModel(IService<IEntity> service)
        {
            this.service = service;
        }

        public virtual async Task OnGetAsync()
        {
            Entities = await service.GetAllAsync();

            if (!IncludedProperties.Any(prop => prop == "Id"))
            {
                IncludedProperties = IncludedProperties.Append("Id");
            }
        }
    }
}
