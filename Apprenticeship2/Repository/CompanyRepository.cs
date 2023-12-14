using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        ApplicationDbContext context;
        public CompanyRepository(ApplicationDbContext context) {
            this.context = context;
        }

        public List<Company> GetAllCompanies()
        {
           return context.companys.ToList();
        }
        public void AddCompany(Company company)
        {
            context.companys.Add(company);
            context.SaveChanges();
        }
        public Company GetCompany(int id)
        {
            return context.companys.Where(x => x.companyId == id).SingleOrDefault();
        }
        public void updateCompanyRecord(Company company)
        {
            context.companys.Update(company);
            context.SaveChanges();
        }
        public void deleteCompany(int id)
        {
            Company company = context.companys.Where(x => x.companyId == id).SingleOrDefault();
            context.companys.Remove(company);
            context.SaveChanges();
        }
    }
}
