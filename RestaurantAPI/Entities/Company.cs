using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class Company
    {
        public Company()
        {
            CompanyAdministrators = new HashSet<CompanyAdministrators>();
            CompanyClients = new HashSet<CompanyClients>();
            CompanyDeliverers = new HashSet<CompanyDeliverers>();
            Dish = new HashSet<Dish>();
            DishCalendar = new HashSet<DishCalendar>();
            Group = new HashSet<Group>();
            Ingredient = new HashSet<Ingredient>();
            Menu = new HashSet<Menu>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public bool Active { get; set; }
        public byte MenuOption { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<CompanyAdministrators> CompanyAdministrators { get; set; }
        public virtual ICollection<CompanyClients> CompanyClients { get; set; }
        public virtual ICollection<CompanyDeliverers> CompanyDeliverers { get; set; }
        public virtual ICollection<Dish> Dish { get; set; }
        public virtual ICollection<DishCalendar> DishCalendar { get; set; }
        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
    }
}
