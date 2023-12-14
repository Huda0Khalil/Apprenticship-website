using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public class ReportStatusRepository : IReportStatusRepository
    {
        ApplicationDbContext context;
        public ReportStatusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<ReportStatus> GetAllReportStatus()
        {
            return context.ReportStatus.ToList();
        }
    }
}
