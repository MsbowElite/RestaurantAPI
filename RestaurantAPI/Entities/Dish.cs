using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class Dish
    {
        public Dish()
        {
            DishCalendar = new HashSet<DishCalendar>();
            DishIngredients = new HashSet<DishIngredients>();
            MenuDishes = new HashSet<MenuDishes>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<DishCalendar> DishCalendar { get; set; }
        public virtual ICollection<DishIngredients> DishIngredients { get; set; }
        public virtual ICollection<MenuDishes> MenuDishes { get; set; }
    }
}
