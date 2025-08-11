using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared
{
    public class BaseDeleteModel<IEntity> : PageModel where IEntity : Entity
    {
        private readonly IService<IEntity> service;

        public BaseDeleteModel(IService<IEntity> service)
        {
            this.service = service;
        }

        public virtual async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var user = await service.GetByIdAsync(id);

            if (user != null)
            {
                await service.DeleteAsync(id);
            }

            return Redirect($"/Admin/{typeof(IEntity).Name}/{typeof(IEntity).Name}List");
        }
    }
}
