using Domain.Generics.Persistance;
using Domain.Generics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Domain.Api.Pages.Admin.Shared.Model
{
    public class BaseCreateModel<IEntity> : PageModel where IEntity : Entity
    {
        protected readonly IService<IEntity> service;

        public object _Entity = Activator.CreateInstance(typeof(IEntity));
        public IEnumerable<string> ExcludedProperties { get; set; } = new List<string>
        {
            nameof(Entity.Id),
            nameof(Entity.CreatedOn),
            nameof(Entity.UpdatedOn),
        };

        public BaseCreateModel(IService<IEntity> service)
        {
            this.service = service;
        }

        public async Task OnGetAsync(Guid? id)
        {
            if (id != null)
            {
                var dbEntity = await service.GetByIdAsync(id);
                _Entity = dbEntity;
            }
        }

        public async Task<IActionResult> OnPostAsync(IEntity entity)
        {
            var dbEntity = await service.GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                await service.CreateAsync(entity);
            }
            else
            {
                await service.UpdateAsync(entity);
            }

            return Redirect($"/Admin/{entity.GetType().Name}/{entity.GetType().Name}List");
        }
    }
}
