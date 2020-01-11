using RestaurantAPI.Entities.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository
{
    public class DishCalendarRepository : RepositoryBase<DishCalendar>, IDishCalendarRepository
    {
        public DishCalendarRepository(ApplicationDbContext applicationDbContext)
    : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<DishCalendar>> GetDishCalendarsByCompanyPerMonthAsync(Guid companyId, byte month, int year)
        {
            return await ListByCondition(d => d.CompanyId == companyId && d.Date.Year == year && (d.Date.Month == month || d.Date.Month == (month - 1) || d.Date.Month == (month + 1)) && d.DeletedAt == null).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<DishCalendar>> GetDishCalendarsByCompanyPerDateAsync(Guid companyId, DateTime date)
        {
            return await ListByCondition(d => d.CompanyId == companyId && d.Date.Date == date && d.DeletedAt == null).Include(i => i.Dish).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<DishCalendar> GetDishCalendarByIdAsync(Guid dishId, Guid companyId, DateTime date)
        {
            return await ApplicationDbContext.DishCalendar
                .SingleOrDefaultAsync(dc => dc.DishId.Equals(dishId) && dc.CompanyId.Equals(companyId) && dc.Date == date);
        }

        public async Task UpdateDishCalendarAsync(DishCalendar dishCalendar)
        {
            dishCalendar.UpdatedAt = DateTime.UtcNow;
            Update(dishCalendar);
            await SaveAsync();
        }

        public async Task CreateDishCalendarAsync(DishCalendar dishCalendar)
        {
            dishCalendar.CreatedAt = DateTime.UtcNow;
            Create(dishCalendar);
            await SaveAsync();
        }
    }
}
