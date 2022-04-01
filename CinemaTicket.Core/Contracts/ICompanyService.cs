using CinemaTicket.Models;
using Microsoft.AspNetCore.Http;


namespace CinemaTicket.Core.Contracts
{
    public interface ICompanyService
    {
        void AddCompany(Company obj, IFormFile? file);

        IEnumerable<Company> GetAllCompanies();

        Company GetCompany(int? id);

        void UpdateCompany(Company obj, IFormFile? file);

        void DeleteCompany(Company model);
    }
}
