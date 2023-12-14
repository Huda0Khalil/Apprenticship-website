using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Apprenticeship2.Controllers
{
    public class TeamLeaderController : Controller
    {
        ITeamLeaderRepository TeamLeaderRepository;
        ICompanyRepository companyRepository;
        ITrainingRepository trainingRepository;
        IAssignmentRepository assignmentRepository;
        IObjectiveRepository objectiveRepository;
        IReportRepository reportRepository;
        IReportLogRepository reportLogRepository;
        IAttatcheFileRepository attatcheFileRepository;
        IRepoertFileRepository repoertFileRepository;
        IStudentRepository studentRepository;
        public TeamLeaderController(ITeamLeaderRepository teamLeaderRepository,
            ICompanyRepository companyRepository,
            ITrainingRepository trainingRepository, 
            IAssignmentRepository assignmentRepository,
            IObjectiveRepository objectiveRepository,
            IReportRepository reportRepository,
            IReportLogRepository reportLogRepository,
            IAttatcheFileRepository attatcheFileRepository,
            IRepoertFileRepository repoertFileRepository,
            IStudentRepository studentRepository)
        {
            this.TeamLeaderRepository = teamLeaderRepository;
            this.companyRepository = companyRepository;
            this.trainingRepository = trainingRepository;
            this.assignmentRepository = assignmentRepository;
            this.objectiveRepository = objectiveRepository;
            this.reportRepository = reportRepository;
            this.reportLogRepository = reportLogRepository;
            this.attatcheFileRepository = attatcheFileRepository;
            this.repoertFileRepository = repoertFileRepository;
            this.studentRepository = studentRepository;
        }
        [Authorize(Roles = "TEAMLEADER")]

        public IActionResult Index()
        {
            string leaderId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //ViewBag.leaders = TeamLeaderRepository.GetAllLeaders();
            ViewBag.trainingCount = trainingRepository.countTraining(leaderId);
            ViewBag.finishedTraining = trainingRepository.countFinishedTraining(leaderId);
            ViewBag.currentTrainings = trainingRepository.countCurrentTraining(leaderId);
            ViewBag.students = studentRepository.TeamLeaderStudents(leaderId).Take<Training>(3).ToList();
            ViewBag.Assignments = assignmentRepository.GetTeamleaderAssignments(leaderId).Take<Assignment>(3).ToList();
            return View();
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult TeamLeadersPage()
        {
            ViewBag.leaders = TeamLeaderRepository.GetAllLeaders();
            return View();
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult AddTeamLeader(InsertTeamLeaderDTO leader)
        {
            ViewBag.companies = companyRepository.GetAllCompanies();
            return View(leader);
        }
        [Authorize(Roles = "ADMIN")]

        public async Task<IActionResult> insertLeader(InsertTeamLeaderDTO leader)
        {
            if(ModelState.IsValid)
            {
                TeamLeader teamLeader = new TeamLeader();
                teamLeader.FirstName = leader.firstName;
                teamLeader.SecondName = leader.secondName;
                teamLeader.ThirdName = leader.thirdName;
                teamLeader.LastName = leader.lastName;

                teamLeader.Email = leader.Email;
                teamLeader.Address = leader.Address;
                teamLeader.Age = leader.Age;
                teamLeader.companyId = leader.companyId;
                teamLeader.PhoneNumber = leader.PhoneNumber;
                if (leader.ConfirmPassword == leader.password)
                {
                    await TeamLeaderRepository.addLeader(teamLeader, leader.password);
                }

                return RedirectToAction("TeamLeadersPage");
            }
            else
            {
                return RedirectToAction("AddTeamLeader", leader);
            }
            
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Update(string TLeader)
        {
            ViewBag.companies = companyRepository.GetAllCompanies();
            return View(TeamLeaderRepository.selectOne(TLeader));
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult updateLeader(TeamLeader teamLeader)
        {
            TeamLeaderRepository.updateLeaderRecord(teamLeader);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult delete(string sup)
        {
            TeamLeaderRepository.deleteLeder(sup);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult TeamLeaderTrainings()
        {
            string leaderId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.trainings = trainingRepository.GetTeamLeaderTrainings(leaderId);
            return View();
        }
        [Authorize(Roles = "TEAMLEADER")]

        public IActionResult ShowReports(int AssignmentId)
        {
            ViewBag.AssignmentID = AssignmentId;
            ViewBag.Reports = reportRepository.GetAssignmentReports(AssignmentId);
            ViewBag.AssignmentTitle = assignmentRepository.GetAssignment(AssignmentId).assignmentTitle;
            return View();
        }
        [Authorize(Roles = "TEAMLEADER")]

        public async Task<IActionResult> ShowOneReport(int ReportId)
        {
            var report = reportRepository.GetReport(ReportId);
            ViewBag.reportStatus = reportRepository.reportStatuses();
            ViewBag.files =  repoertFileRepository.GetReportFile(ReportId);
            return View(report);
        }
        [Authorize(Roles = "TEAMLEADER")]

        public IActionResult changeReportStatus(Report rep)
        {
            reportRepository.changeReportStatusFun(rep);
            Report report = reportRepository.GetReport(rep.reportId);
            reportLogRepository.AddToReportLog(report);
            
            return RedirectToAction("ShowReports", new { AssignmentId = report.assignmentId});
        }
        
    }
}
