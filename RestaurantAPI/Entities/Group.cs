using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class Group
    {
        public Group()
        {
            GroupClients = new HashSet<GroupClients>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? CompanyId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Company Company { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<GroupClients> GroupClients { get; set; }
    }
}
