using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface ICompanyRepository
    {
        public List<Company> GetAllCompanies();
        public void AddCompany(Company company);
        public Company GetCompany(int id);
        public void updateCompanyRecord(Company company);
        public void deleteCompany(int id);
    }
}
