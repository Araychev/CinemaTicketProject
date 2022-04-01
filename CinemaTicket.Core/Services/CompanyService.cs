using CinemaTicket.Core.Contracts;
using CinemaTicket.Infrastructure.Data.Repositories.IRepository;
using CinemaTicket.Models;
using Microsoft.AspNetCore.Http;


namespace CinemaTicket.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _db;

        public CompanyService(IUnitOfWork db)
        {
            _db = db;
        }

        public void AddCompany(Company obj, IFormFile? file)
        {
            _db.Company.Add(obj);
            _db.Save();
        }

        public void DeleteCompany(Company obj)
        {
            _db.Company.Remove(obj);
            _db.Save();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
           return _db.Company.GetAll();
        }

        public Company GetCompany(int? id)
        {
            
            var company = _db.Company.GetFirstOrDefault(u => u.Id == id);
            return company;
        }

        public void UpdateCompany(Company obj, IFormFile? file)
        {
            _db.Company.Update(obj);
            _db.Save();
        }

       
    }
}
