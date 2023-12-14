using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Apprenticeship2.Controllers
{
    [Authorize(Roles = "STUDENT")]
    public class ReportController : Controller
    {
        IReportRepository reportRepository;
        IAssignmentRepository assignmentRepository;
        IReportLogRepository reportLogRepository;
        IRepoertFileRepository repoertFileRepository;
        public ReportController(IReportRepository reportRepository,
            IAssignmentRepository assignmentRepository,
            IReportLogRepository reportLogRepository,
                    IRepoertFileRepository repoertFileRepository) { 
            this.reportRepository = reportRepository;
            this.assignmentRepository = assignmentRepository;
            this.reportLogRepository = reportLogRepository;
            this.repoertFileRepository = repoertFileRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowReports(int AID)
        {
            ViewBag.AssignmentID = AID;
            ViewBag.Reports = reportRepository.GetAssignmentReports(AID);
           ViewBag.AssignmentTitle = assignmentRepository.GetAssignment(AID).assignmentTitle;
            return View();
        }
        [Authorize(Roles = "STUDENT")]

        public IActionResult Add(InserReportDTO rep)
        {
            ViewBag.AssignmentID = rep.assignmentId;
            ViewBag.AssignmentTitle = assignmentRepository.GetAssignment(rep.assignmentId).assignmentTitle;
            return View(rep);
        }
        [Authorize(Roles = "STUDENT")]

        [HttpPost]
        public IActionResult insertReport(InserReportDTO rep)
        {
            if(ModelState.IsValid)
            {
                reportRepository.createReport(rep);
                return RedirectToAction("ShowReports", new { AID = rep.assignmentId});
            }
            else
            {
                return RedirectToAction("Add",rep);
            }
            
        }
        [Authorize(Roles = "STUDENT")]

        public IActionResult Update(int reportID)
        {

          Report report = reportRepository.GetReport(reportID);
          ViewBag.files =  repoertFileRepository.GetReportFile(reportID);
            return View(reportRepository.ReporToUpdateReportDTO(report));
        }
        [Authorize(Roles = "STUDENT")]

        [HttpPost]
        public IActionResult UpdateReport(UpdateReportDTO report)
        {
            reportRepository.updateReportRecord(report);
            int reportLogId = reportLogRepository.AddToReportLog(reportRepository.GetReport(report.reportID)); 
            repoertFileRepository.AddFile(report.upFiles, report.reportID, reportLogId);

          
            return RedirectToAction("ShowReports", new { AID = report.assignmentId });

           
        }
        public FileStreamResult GetFile(long attachmentId)
        {
            return repoertFileRepository.GetFile(attachmentId);

        }
        [Authorize(Roles = "STUDENT")]

        public IActionResult DeleteFileReport(int fileId, int reportID)
        {
            repoertFileRepository.deleteFile(fileId);
            return RedirectToAction("Update", "Report", new { reportID = reportID });
        }
        [Authorize(Roles = "STUDENT")]

        public IActionResult Delete(int ReportID)
        {
            reportRepository.deleteReport(ReportID);
            return View();
        }
      
    }
}
