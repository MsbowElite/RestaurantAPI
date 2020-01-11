using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using System.Linq;
using RestaurantAPI.Entities.Repository.Interfaces;
using System.Collections.Generic;
using System;
using RestaurantAPI.Models;

namespace RestaurantAPI.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly IRepositoryWrapper _rw;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, IRepositoryWrapper rw)
        {
            _db = db;
            _rw = rw;
        }

        public void Initialize()
        {
            //if (_db.Database.GetPendingMigrations().Any())
            //{
            //    _db.Database.Migrate();
            //}

            if (_db.Role.Count() == 0)
            {
                List<Role> roles = new List<Role>()
                {
                    new Role
                    {
                    CreatedAt = DateTime.UtcNow,
                    Id = StaticRoles.Admin
                    },
                    new Role
                    {
                    CreatedAt = DateTime.UtcNow,
                    Id = StaticRoles.Business
                    },
                    new Role
                    {
                    CreatedAt = DateTime.UtcNow,
                    Id = StaticRoles.Default
                    },
                    new Role
                    {
                    CreatedAt = DateTime.UtcNow,
                    Id = StaticRoles.Customer
                    }
                };

                _db.Role.AddRangeAsync(roles);
                _db.SaveChangesAsync();
            }
        }
    }
}
