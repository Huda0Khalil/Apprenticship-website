using Apprenticeship2.Data.Entities;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship2.Controllers
{
    [Authorize(Roles = "ADMIN")]

    public class CompanyController : Controller
    {
        ICompanyRepository companyRepository;
        public CompanyController(ICompanyRepository companyRepository) { 
            this.companyRepository = companyRepository;
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Index()
        {
            ViewBag.companies = companyRepository.GetAllCompanies();
            return View();
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Add(Company company)
        {
            return View(company);
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult InsertCompany(Company company)
        {
            //if(ModelState.IsValid)
            //{
                companyRepository.AddCompany(company);
                return RedirectToAction("Index");
            //}
            //else
            //{
                return RedirectToAction("Add", company);
            //}
            
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Update(int comId)
        {
            
            return View(companyRepository.GetCompany(comId));
        }
        [Authorize(Roles = "ADMIN")]


        public IActionResult UpdateCompany(Company company)
        {
            companyRepository.updateCompanyRecord(company);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Delete(int comId)
        {
            companyRepository.deleteCompany(comId);
            return RedirectToAction("Index");
        }
    }
}
