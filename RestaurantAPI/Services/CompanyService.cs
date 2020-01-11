using RestaurantAPI.Entities;
using RestaurantAPI.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface ICompanyService
    {
        Task<bool> AddDishCalendar(DishCalendar dishCalendar);
        Task<int> RemoveDishCalendar(DishCalendar dishCalendar);
    }
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryWrapper _rw;
        private readonly ApplicationDbContext _db;

        public CompanyService(ApplicationDbContext db, IRepositoryWrapper rw)
        {
            _rw = rw;
            _db = db;
        }

        public async Task<bool> AddDishCalendar(DishCalendar dishCalendar)
        {
            var checkDishCalendar = await _rw.DishCalendar.GetDishCalendarByIdAsync(dishCalendar.DishId, dishCalendar.CompanyId, dishCalendar.Date.Date);
            if (checkDishCalendar != null)
                if (checkDishCalendar.DeletedAt == null)
                    throw new System.Exception("Ingredient already added");
                else
                {

                    checkDishCalendar.DeletedAt = null;
                    await _rw.DishCalendar.UpdateDishCalendarAsync(checkDishCalendar);
                    return true;
                }

            await _rw.DishCalendar.CreateDishCalendarAsync(dishCalendar);
            return true;
        }

        public async Task<int> RemoveDishCalendar(DishCalendar dishCalendar)
        {
            var localDishCalendar = await _rw.DishCalendar.GetDishCalendarByIdAsync(dishCalendar.DishId, dishCalendar.CompanyId, dishCalendar.Date);

            if (localDishCalendar == null)
                throw new System.Exception("DishCalendar does not exist");
            if (localDishCalendar.DeletedAt != null)
                throw new System.Exception("DishCalendar is removed already");

            localDishCalendar.DeletedAt = DateTime.UtcNow;
            _db.DishCalendar.Update(localDishCalendar);
            return await _db.SaveChangesAsync();
        }
    }
}
