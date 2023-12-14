using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship2.Repository
{
    public interface IAttatcheFileRepository
    {
        public void AddFile(IEnumerable<IFormFile> upFiles, int assID);

        public Task<List<AssignmentFiles>> GetAssignmentFileAsync(int assID);
        public List<AssignmentFiles> GetAssignmentFile(int assID);
        public FileStreamResult GetFile(long attachmentId);
        public void deleteFile(int fileId);
    }
}
