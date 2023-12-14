using Apprenticeship2.Data;
using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;

namespace Apprenticeship2.Repository
{
    public class AttatcheFileRepository : IAttatcheFileRepository
    {
       public ApplicationDbContext context;
        public AttatcheFileRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddFile(IEnumerable<IFormFile> upFiles, int assID)
        {
           
            foreach (IFormFile upFile in upFiles)
            {
                AssignmentFiles x0 = new AssignmentFiles();
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
                    x0.AssignmentId = assID;
                   
                     context.assignmentFiles.Add(x0);
                     context.SaveChanges();
                   
                }
            }
            

        }
       

        public async Task<List<AssignmentFiles>> GetAssignmentFileAsync(int assID)
        {
            return  context.assignmentFiles.Where(x => x.AssignmentId == assID).ToList();
        }
        public List<AssignmentFiles> GetAssignmentFile(int assID)
        {
            return context.assignmentFiles.Where(x => x.AssignmentId == assID ).ToList();
        }
       
        /*public async Task<List<AssignmentFiles>> GetReportFileAsync(int reportID)
        {
            return context.reportFiles.Where(x => x.reportId == reportID).ToList();
        }*/
       
        public FileStreamResult GetFile(long attachmentId)
        {
            var file = context.assignmentFiles.Where(x => x.assignmentFilesId == attachmentId).SingleOrDefault();
            Stream stream = new MemoryStream(file.file);
            return new FileStreamResult(stream, file.contentType);
        }
        public  void deleteFile(int fileId)
        {
            
            var file = context.assignmentFiles.Where(x => x.assignmentFilesId == fileId).SingleOrDefault();
           
         
            
               /* file.file = new byte[0];
                context.fileAttatchments.Update(file);
                context.SaveChanges();
               */
                context.assignmentFiles.Remove(file);
                  context.SaveChanges();
            
        }
    }
}
