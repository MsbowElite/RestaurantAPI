using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantAPI.Entities
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyAdministrators> CompanyAdministrators { get; set; }
        public virtual DbSet<CompanyClients> CompanyClients { get; set; }
        public virtual DbSet<CompanyDeliverers> CompanyDeliverers { get; set; }
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<DishCalendar> DishCalendar { get; set; }
        public virtual DbSet<DishIngredients> DishIngredients { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupClients> GroupClients { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuDishes> MenuDishes { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<WeeklyMenus> WeeklyMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.MenuOption).HasDefaultValueSql("(CONVERT([tinyint],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OwnerId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Companies_Users_OwnerId");
            });

            modelBuilder.Entity<CompanyAdministrators>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.UserId });

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyAdministrators)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyAdministrators_Companies_CompanyId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompanyAdministrators)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CompanyAdministrators_Users_UserId");
            });

            modelBuilder.Entity<CompanyClients>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.UserId });

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyClients)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyClients_Companies_CompanyId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompanyClients)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CompanyClients_Users_UserId");
            });

            modelBuilder.Entity<CompanyDeliverers>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.UserId });

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyDeliverers)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_CompanyDeliverers_Companies_CompanyId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CompanyDeliverers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CompanyDeliverers_Users_UserId");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.CompanyId })
                    .HasName("Name_CompanyDishes_Unique_By_CompanyId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Dish)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyDishes_Companies_CompanyId");
            });

            modelBuilder.Entity<DishCalendar>(entity =>
            {
                entity.HasKey(e => new { e.DishId, e.CompanyId, e.Date });

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.DishCalendar)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DishCalendar_Company");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.DishCalendar)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DishCalendar_Dish");
            });

            modelBuilder.Entity<DishIngredients>(entity =>
            {
                entity.HasKey(e => new { e.DisheId, e.IngredientId })
                    .HasName("PK_DisheIngredients");

                entity.HasOne(d => d.Dishe)
                    .WithMany(p => p.DishIngredients)
                    .HasForeignKey(d => d.DisheId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DisheIngredients_CompanyDishes");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.DishIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DisheIngredients_Ingredients");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Groups_Companies_CompanyId");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Group)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Groups_Users_OwnerId");
            });

            modelBuilder.Entity<GroupClients>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.UserId });

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupClients)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_GroupClients_Groups_GroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupClients)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_GroupClients_Users_UserId");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.CompanyId })
                    .HasName("Name_Ingredients_Unique_By_CompanyId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredients_Companies");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.CompanyId })
                    .HasName("Name_CompanyMenus_Unique_By_CompanyId")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(400);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyMenus_Companies");
            });

            modelBuilder.Entity<MenuDishes>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.DisheId })
                    .HasName("PK_CompanyMenuDishes");

                entity.HasIndex(e => new { e.DisheId, e.MenuId })
                    .HasName("AK_CompanyMenuDishes_CompanyDishId_CompanyMenuId")
                    .IsUnique();

                entity.HasOne(d => d.Dishe)
                    .WithMany(p => p.MenuDishes)
                    .HasForeignKey(d => d.DisheId)
                    .HasConstraintName("FK_CompanyMenuDishes_CompanyDishes_CompanyDishId");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuDishes)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_CompanyMenuDishes_CompanyMenus_CompanyMenuId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(22);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });

                entity.Property(e => e.RoleId).HasMaxLength(20);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users_UserId");
            });

            modelBuilder.Entity<WeeklyMenus>(entity =>
            {
                entity.HasKey(e => new { e.WeekDay, e.CompanyMenusId })
                    .HasName("PK_WeeklyMenus_1");

                entity.HasOne(d => d.CompanyMenus)
                    .WithMany(p => p.WeeklyMenus)
                    .HasForeignKey(d => d.CompanyMenusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeeklyMenus_CompanyMenus_CompanyMenusId");
            });
        }
    }
}
