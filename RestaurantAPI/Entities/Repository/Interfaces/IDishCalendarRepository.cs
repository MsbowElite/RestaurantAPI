using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository.Interfaces
{
    public interface IDishCalendarRepository
    {
        Task<IEnumerable<DishCalendar>> GetDishCalendarsByCompanyPerMonthAsync(Guid companyId, byte month, int year);
        Task<IEnumerable<DishCalendar>> GetDishCalendarsByCompanyPerDateAsync(Guid companyId, DateTime date);
        Task<DishCalendar> GetDishCalendarByIdAsync(Guid dishId, Guid companyId, DateTime date);
        Task CreateDishCalendarAsync(DishCalendar dishCalendar);
        Task UpdateDishCalendarAsync(DishCalendar dishCalendar);
    }
}
