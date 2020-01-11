using System;
using System.Collections.Generic;

namespace RestaurantAPI.Entities
{
    public partial class User
    {
        public User()
        {
            Company = new HashSet<Company>();
            CompanyAdministrators = new HashSet<CompanyAdministrators>();
            CompanyClients = new HashSet<CompanyClients>();
            CompanyDeliverers = new HashSet<CompanyDeliverers>();
            Group = new HashSet<Group>();
            GroupClients = new HashSet<GroupClients>();
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<CompanyAdministrators> CompanyAdministrators { get; set; }
        public virtual ICollection<CompanyClients> CompanyClients { get; set; }
        public virtual ICollection<CompanyDeliverers> CompanyDeliverers { get; set; }
        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<GroupClients> GroupClients { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
