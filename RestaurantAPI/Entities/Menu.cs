using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            MenuDishes = new HashSet<MenuDishes>();
            WeeklyMenus = new HashSet<WeeklyMenus>();
        }

        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<MenuDishes> MenuDishes { get; set; }
        public virtual ICollection<WeeklyMenus> WeeklyMenus { get; set; }
    }
}
