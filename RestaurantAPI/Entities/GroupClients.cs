using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class GroupClients
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
