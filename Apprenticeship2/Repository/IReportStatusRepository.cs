using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface IReportStatusRepository
    {
        public List<ReportStatus> GetAllReportStatus();
    }
}
