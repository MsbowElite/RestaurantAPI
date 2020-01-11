using RestaurantAPI.Entities;
using RestaurantAPI.Entities.Repository.Interfaces;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IMenuService
    {
        Task<bool> AddDishe(Guid menuId, Guid disheId);
        Task<int> RemoveDishe(Guid menuId, Guid disheId);
    }
    public class MenuService : IMenuService
    {
        private readonly IRepositoryWrapper _rw;
        private readonly ApplicationDbContext _db;

        public MenuService(ApplicationDbContext db, IRepositoryWrapper rw)
        {
            _rw = rw;
            _db = db;
        }

        public async Task<bool> AddDishe(Guid menuId, Guid disheId)
        {
            var menu = await _rw.Menu.GetMenuByIdWithDishesAsync(menuId);

            var menuDishe = menu.MenuDishes.FirstOrDefault(f => f.DisheId == disheId);
            if (menuDishe != null)
                if (menuDishe.DeletedAt == null)
                    throw new System.Exception("Dishe already added");
                else
                {
                    menuDishe.DeletedAt = null;
                    _db.MenuDishes.Update(menuDishe);
                    await _rw.SaveChanges();
                    return true;
                }

            menu.MenuDishes.Add(new Entities.MenuDishes()
            { DisheId = disheId, MenuId = menuId, CreatedAt = DateTime.UtcNow });
            await _rw.SaveChanges();

            return true;
        }

        public async Task<int> RemoveDishe(Guid menuId, Guid disheId)
        {
            var menu = await _rw.Menu.GetMenuByIdWithDishesAsync(menuId);

            var menuDishe = menu.MenuDishes.FirstOrDefault(f => f.DisheId == disheId);
            if (menuDishe == null)
                throw new System.Exception("Dishe does not exist");
            if (menuDishe.DeletedAt != null)
                throw new System.Exception("Dishe does not exist");

            menuDishe.DeletedAt = DateTime.UtcNow;
            _db.MenuDishes.Update(menuDishe);
            return await _db.SaveChangesAsync();
        }
    }
}
