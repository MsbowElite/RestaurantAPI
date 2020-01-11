using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
