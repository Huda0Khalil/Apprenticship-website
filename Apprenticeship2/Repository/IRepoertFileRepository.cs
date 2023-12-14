using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship2.Repository
{
    public interface IRepoertFileRepository 
    {
        public void AddFile(IEnumerable<IFormFile> upFiles, int reportID, int reporLogId);
        public List<ReportFiles> GetReportFile(int reportID);
        public FileStreamResult GetFile(long attachmentId);
        public void deleteFile(int fileId);
        //public Task<List<AssignmentFiles>> GetReportFileAsync(int reportID);
         public List<ReportFiles> GetAssignmentReportFile(int assID);

    }

}
