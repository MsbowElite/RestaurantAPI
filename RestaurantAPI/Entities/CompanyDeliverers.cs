using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class CompanyDeliverers
    {
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}
