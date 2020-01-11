using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class MenuDishes
    {
        public Guid MenuId { get; set; }
        public Guid DisheId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Dish Dishe { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
