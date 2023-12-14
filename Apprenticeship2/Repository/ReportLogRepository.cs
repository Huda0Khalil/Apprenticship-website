using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Repository
{
    public class ReportLogRepository : IReportLogRepository
    {
        ApplicationDbContext context;
        public ReportLogRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int AddToReportLog(Report repo)
        {
            ReportLog reportLog = new ReportLog();
            reportLog.reportId = repo.reportId;
            reportLog.reportName = repo.reportName;
            reportLog.reportDescription = repo.reportDescription;
            reportLog.reportNotes = repo.reportNotes;
            reportLog.reportStatusId = repo.reportStatusId;
            reportLog.logDate = DateTime.Now ;
            context.reportLogs.Add(reportLog);
            context.SaveChanges();
            return reportLog.reportLogId;
        }
        public IEnumerable<ReportLog> GetAllReportLogs(int assignmentId)
        {
            
            List<ReportLog> reportLogs = context.reportLogs.Include(x => x.report).ThenInclude(x => x.reportStatus).Include(x => x.reportFiles).Include(x=>x.report.assignment).Where(x=>x.report.assignmentId == assignmentId).ToList();

                IEnumerable<ReportLog> sortedReportLogs = from R in reportLogs orderby R.logDate descending select R ;
            return sortedReportLogs;
        }
    }
}
