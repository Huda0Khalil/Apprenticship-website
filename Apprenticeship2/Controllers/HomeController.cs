using Apprenticeship2.Models;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Apprenticeship2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ITrainingRepository trainingRepository;
           IStudentRepository studentRepository;
            IUniversityRepository universityRepository;
            ITeamLeaderRepository teamLeaderRepository;
            ICompanyRepository companyRepository;
        public HomeController(ILogger<HomeController> logger,
            ITrainingRepository trainingRepository,
            IStudentRepository studentRepository,
            IUniversityRepository universityRepository,
            ITeamLeaderRepository teamLeaderRepository,
            ICompanyRepository companyRepository)
        {
            _logger = logger;
            this.trainingRepository = trainingRepository;
            this.studentRepository = studentRepository;
            this.universityRepository = universityRepository;
            this.teamLeaderRepository = teamLeaderRepository;
            this.companyRepository = companyRepository;
        }
      public IActionResult First()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewBag.Trainings = trainingRepository.GetAllTraining().Count();
            ViewBag.students = studentRepository.GetAllStudents().Count();
            ViewBag.teamleader = teamLeaderRepository.GetAllLeaders().Count();
            ViewBag.supervisor = universityRepository.AllUniversities().Count();
            ViewBag.company = companyRepository.GetAllCompanies().Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}