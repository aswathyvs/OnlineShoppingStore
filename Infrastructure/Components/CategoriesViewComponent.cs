using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.Data.Repository;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Infrastructure.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IRepository<Category> _repository;

        public CategoriesViewComponent(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var items = _repository.GetAll().ToList();
            return View(items);
        }
    }
}
