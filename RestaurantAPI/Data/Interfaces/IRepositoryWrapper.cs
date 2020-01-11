using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        Task SaveChanges();
        IUserRepository User { get; }
        ICompanyRepository Company { get; }
        IDishRepository Dish { get; }
        IDishCalendarRepository DishCalendar { get; }
        IIngredientRepository Ingredient { get; }
        IMenuRepository Menu { get; }
    }
}
