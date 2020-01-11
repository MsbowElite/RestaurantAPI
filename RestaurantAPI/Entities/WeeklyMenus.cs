using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class WeeklyMenus
    {
        public byte WeekDay { get; set; }
        public Guid CompanyMenusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Menu CompanyMenus { get; set; }
    }
}
