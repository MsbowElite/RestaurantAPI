using RestaurantAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await ListAll().OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            return await FindByConditionAsync(company => company.Id.Equals(companyId) && company.DeletedAt == null);
        }

        public async Task<bool> CheckManagerAuthorizationAsync(Guid companyId, Guid userId)
        {
            return await CheckAnyByConditionAsync(company => company.Id == companyId && company.OwnerId == userId);
        }

        public async Task CreateCompanyAsync(Company company, Guid userId)
        {
            company.OwnerId = userId;
            company.CreatedAt = DateTime.UtcNow;
            Create(company);
            await SaveAsync();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            company.UpdatedAt = DateTime.UtcNow;
            Update(company);
            await SaveAsync();
        }

        public async Task DeleteCompanyAsync(Company company)
        {
            company.DeletedAt = DateTime.UtcNow;
            Update(company);
            await SaveAsync();
        }

        public async Task<IEnumerable<Company>> GetMyOwnCompaniesAsync(Guid userId)
        {
            return await ListByCondition(company => company.OwnerId == userId && company.DeletedAt == null).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }
    }
}
