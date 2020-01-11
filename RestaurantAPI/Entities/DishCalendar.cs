using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class DishCalendar
    {
        public Guid DishId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Company Company { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
