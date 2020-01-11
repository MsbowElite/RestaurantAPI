using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<IEnumerable<Company>> GetMyOwnCompaniesAsync(Guid userId);
        Task<Company> GetCompanyByIdAsync(Guid companyId);
        Task<bool> CheckManagerAuthorizationAsync(Guid companyId, Guid userId);
        Task CreateCompanyAsync(Company company, Guid userId);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(Company company);
    }
}
