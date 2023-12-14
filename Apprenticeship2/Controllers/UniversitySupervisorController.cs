using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Apprenticeship2.Controllers
{
    public class UniversitySupervisorController : Controller
    {
        IUniversitySupervisorRepository universitySupervisorRepository;
        IUniversityRepository universityRepository;
        ITrainingRepository trainingRepository;
        IAssignmentRepository assignmentRepository;
        IReportRepository reportRepository;
        IReportLogRepository reportLogRepository;
        IAttatcheFileRepository attatcheFileRepository;
        IReportStatusRepository reportStatusRepository;
        IRepoertFileRepository repoertFileRepository;
        IStudentRepository studentRepository;
        ICompanyRepository companyRepository;
        public UniversitySupervisorController(IUniversitySupervisorRepository universitySupervisorRepository,
            IUniversityRepository universityRepository,
            ITrainingRepository trainingRepository,
            IAssignmentRepository assignmentRepository,
            IReportRepository reportRepository,
            IReportLogRepository reportLogRepository,
            IAttatcheFileRepository attatcheFileRepository,
            IReportStatusRepository reportStatusRepository,
            IRepoertFileRepository repoertFileRepository,
            IStudentRepository studentRepository,
            ICompanyRepository companyRepository)
        {
            this.universitySupervisorRepository = universitySupervisorRepository;
            this.universityRepository = universityRepository;
            this.trainingRepository = trainingRepository;
            this.assignmentRepository = assignmentRepository;
            this.reportRepository = reportRepository;
            this.reportLogRepository = reportLogRepository;
            this.reportLogRepository = reportLogRepository;
            this.attatcheFileRepository = attatcheFileRepository;
            this.reportStatusRepository = reportStatusRepository;
            this.repoertFileRepository = repoertFileRepository;
            this.studentRepository = studentRepository;
            this.companyRepository = companyRepository;
        }
        [Authorize(Roles = "UNIVERSITYSUPERVISOR")]

        public IActionResult Index()
        {
            string supervisorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            ViewBag.Students = studentRepository.SupervisorStudents(supervisorId);
            ViewBag.companaies = companyRepository.GetAllCompanies();
            ViewBag.trainings = trainingRepository.GetSupervisorTrainings(supervisorId);
            return View();
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult UniversitySupervisorPage()
        {

            ViewBag.sup = universitySupervisorRepository.GetAllSupervisor();
            return View();
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Add(InsertUniversitySupervisorDTO sup)
        {
            ViewBag.universities = universityRepository.AllUniversities();
            return View(sup);

        }
        [Authorize(Roles = "ADMIN")]

        public async Task<IActionResult> insertSupervisor(InsertUniversitySupervisorDTO sup)
        {
            if(ModelState.IsValid)
            {
                UniversitySupervisor supervisor = new UniversitySupervisor();
                supervisor.FirstName = sup.firstName;
                supervisor.SecondName = sup.secondName;
                supervisor.ThirdName = sup.thirdName;
                supervisor.Address = sup.Address;
                supervisor.LastName = sup.lastName;
                supervisor.UserName = sup.Email.ToUpper();
                supervisor.NormalizedUserName = sup.Email.ToUpper();
                supervisor.Email = sup.Email.ToUpper();
                supervisor.NormalizedEmail = sup.Email.ToUpper();
                supervisor.Age = sup.Age;
                supervisor.universityId = sup.universityId;
                supervisor.PhoneNumber = sup.PhoneNumber;
                if (sup.ConfirmPassword == sup.password)//I must make notification to user
                {
                    await universitySupervisorRepository.addSupervisor(supervisor, sup.password);

                }
                return RedirectToAction("UniversitySupervisorPage");

            }
            else
            {
                return RedirectToAction("Add", sup);
            }

        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Update(string sup)
        {
            ViewBag.universities = universityRepository.AllUniversities();

            return View(universitySupervisorRepository.selectOne(sup));
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult updateSupervisor(UniversitySupervisor supervisor)
        {
            universitySupervisorRepository.updateSupervisorRecord(supervisor);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult delete(string sup)
        {
            universitySupervisorRepository.deleteSupervisor(sup);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "UNIVERSITYSUPERVISOR")]

        public IActionResult ShowTrainings()
        {

            string supervisor = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.trainings = trainingRepository.GetSupervisorTrainings(supervisor);
            return View();
        }
        [Authorize(Roles = "UNIVERSITYSUPERVISOR")]

        public IActionResult showAssignment(int TID)
        {
            ViewBag.TID = TID;
            ViewBag.Ass = assignmentRepository.GetTrainingAssignments(TID);
            return View();
        }
        [Authorize(Roles = "UNIVERSITYSUPERVISOR")]

        public IActionResult ShowOneAssignment(int AID)
        {
            ViewBag.Assignment = assignmentRepository.getOneSupervisorAssignment(AID);
            return View();
        }
        [Authorize(Roles = "UNIVERSITYSUPERVISOR")]

        public IActionResult ShowReports(int AssignmentId)
        {
            ViewBag.AssignmentID = AssignmentId;
            ViewBag.Reports = reportRepository.GetAssignmentReports(AssignmentId);
            ViewBag.AssignmentTitle = assignmentRepository.GetAssignment(AssignmentId).assignmentTitle;
            return View();
        }
        [Authorize(Roles = "UNIVERSITYSUPERVISOR")]

        public IActionResult ShowOneReport(int ReportId)
        {
            var report = reportRepository.GetReport(ReportId);
            ViewBag.reportStatus = reportRepository.reportStatuses();
            return View(report);
        }
        [Authorize(Roles = "UNIVERSITYSUPERVISOR")]
        public IActionResult ShowTimeLine(int AssignmentId)
        {
            ViewBag.AssignmentID = AssignmentId;
            ViewBag.Reports = reportRepository.GetAssignmentReports(AssignmentId);
            ViewBag.AssignmentTitle = assignmentRepository.GetAssignment(AssignmentId).assignmentTitle;
           // IEnumerable<ReportLog> reportLogs = reportLogRepository.GetAllReportLogs();
           ViewBag.reportLogs = reportLogRepository.GetAllReportLogs(AssignmentId);
          //  ViewBag.files = repoertFileRepository.GetAssignmentReportFile(AssignmentId);
            ViewBag.status = reportStatusRepository.GetAllReportStatus();
            return View();
        }
    }
}
