using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship2.Repository
{
    public class ReportFileRepository : IRepoertFileRepository
    {
        public ApplicationDbContext context;
        public ReportFileRepository(ApplicationDbContext context)
        {
           this.context = context;
        }
         public List<ReportFiles> GetReportFile(int reportID)
        {
            return context.reportFiles.Where(x => x.reportId == reportID).ToList();
        }
         public List<ReportFiles> GetAssignmentReportFile(int assID)
        {
            return context.reportFiles.Where(x => x.report.assignmentId == assID).ToList();
        }
        public FileStreamResult GetFile(long attachmentId)
        {
            var file = context.reportFiles.Where(x => x.reportFilesId == attachmentId).SingleOrDefault();
            Stream stream = new MemoryStream(file.file);
            return new FileStreamResult(stream, file.contentType);
           
        }
        public void deleteFile(int fileId)
        {

            var file = context.reportFiles.Where(x => x.reportFilesId == fileId).SingleOrDefault();

            context.reportFiles.Remove(file);
            context.SaveChanges();
           
        }
    
    public void AddFile(IEnumerable<IFormFile> upFiles, int reportID, int reporLogId)
        {
            foreach (IFormFile upFile in upFiles)
            {
                ReportFiles x0 = new ReportFiles();
                if (upFile.Length > 0)
                {
                    Stream st = upFile.OpenReadStream();
                    using (BinaryReader br = new BinaryReader(st))
                    {
                        var byteFile = br.ReadBytes((int)st.Length);
                        x0.file = byteFile;
                    }
                    x0.name = upFile.FileName;
                    x0.contentType = upFile.ContentType;

                    x0.reportId = reportID;
                    x0.reportLogId = reporLogId;
                    context.reportFiles.Add(x0);
                    context.SaveChanges();

                }
            }
        }

        
    }
}
