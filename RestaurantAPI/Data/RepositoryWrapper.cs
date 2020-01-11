using RestaurantAPI.Entities.Repository.Interfaces;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IUserRepository _usersRepository;
        private ICompanyRepository _companiesRepository;
        private IDishRepository _dishRepository;
        private IDishCalendarRepository _dishCalendarRepository;
        private IIngredientRepository _ingredientsRepository;
        private IMenuRepository _companyMenusRepository;

        public IUserRepository User => _usersRepository ?? (_usersRepository = new UserRepository(_applicationDbContext));

        public ICompanyRepository Company => _companiesRepository ?? (_companiesRepository = new CompanyRepository(_applicationDbContext));

        public IDishRepository Dish => _dishRepository ?? (_dishRepository = new DishRepository(_applicationDbContext));

        public IDishCalendarRepository DishCalendar => _dishCalendarRepository ?? (_dishCalendarRepository = new DishCalendarRepository(_applicationDbContext));

        public IIngredientRepository Ingredient => _ingredientsRepository ?? (_ingredientsRepository = new IngredientRepository(_applicationDbContext));

        public IMenuRepository Menu => _companyMenusRepository ?? (_companyMenusRepository = new MenuRepository(_applicationDbContext));

        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task SaveChanges()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
