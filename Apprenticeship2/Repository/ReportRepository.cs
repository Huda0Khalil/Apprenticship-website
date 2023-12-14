using Apprenticeship2.Data;
using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Repository
{
    public class ReportRepository : IReportRepository
    {
        ApplicationDbContext context;
        IRepoertFileRepository repoertFileRepository;
        IReportLogRepository reportLogRepository;
       public ReportRepository(ApplicationDbContext context, IRepoertFileRepository repoertFileRepository, IReportLogRepository reportLogRepository)
        {
            this.context = context;
            this.repoertFileRepository = repoertFileRepository;
            this.reportLogRepository = reportLogRepository;
        }
        public List<Report> GetAssignmentReports(int AssignmentID)
        {
            return context.Reports.Include(R => R.assignment).Include(R => R.reportStatus).Where(R => R.assignmentId == AssignmentID).ToList();
        }
       
        public void createReport(InserReportDTO report)
        {
            Report rep = new Report();
            rep.reportName = report.reportName;
            rep.reportDescription = report.reportDescription;
            rep.reportNotes = report.reportNotes;
            rep.assignmentId = report.assignmentId;
            
           rep.reportStatusId = 1;
          
            context.Reports.Add(rep);
            context.SaveChanges();
            int reporLogId = reportLogRepository.AddToReportLog(rep);
            repoertFileRepository.AddFile(report.upFiles, rep.reportId, reporLogId);

           
            
            //attatcheFileRepository.AddFile
            //await attatcheFileRepository.AddFile(inserAssignmentDTO.upFiles, assignment.AssignmentId);

        }
        public Report GetReport(int ReportID)
        {
          return  context.Reports.Include(x => x.assignment).Include(x => x.reportFiles).Include(x => x.reportStatus).Where( R => R.reportId == ReportID ).SingleOrDefault();
        }
        public void updateReportRecord(UpdateReportDTO report)
        {
            Report oldReport = GetReport(report.reportID);
            oldReport.reportStatusId = 1;

            context.Reports.Update(oldReport);
            context.SaveChanges();

        }
        public void deleteReport(int ReportID)
        {
            Report report = GetReport(ReportID);
            context.Reports.Remove(report);
            context.SaveChanges();
        }
        public List<ReportStatus> reportStatuses()
        {
            return context.ReportStatus.ToList();
        }
        public void changeReportStatusFun(Report rep)
        {
            Report report = GetReport(rep.reportId);
            report.reportStatusId = rep.reportStatusId;
            context.Reports.Update(report);
            context.SaveChanges();
        }
        public UpdateReportDTO ReporToUpdateReportDTO(Report rep)
        {
            UpdateReportDTO updateReportDTO = new UpdateReportDTO();
            updateReportDTO.reportID = rep.reportId;
            updateReportDTO.reportNotes = rep.reportNotes;
            updateReportDTO.reportName = rep.reportName;
            updateReportDTO.reportDescription = rep.reportDescription;
            updateReportDTO.assignmentId = rep.assignmentId;
            //var files = context.fileAttatchments.Where(x => x.AssignmentId == rep.reportId).ToList();

            
            return updateReportDTO;
        }
       /* public List<Report> lastReportInAssignment(int AID, int RID)
        {
           return  context.Reports.Include(x => x.reportFiles).Where(x => x.assignmentId == AID && x.reportId == RID).ToList();
        }
       */

    }
}
