using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship2.Controllers
{
    public class AttachmentFile : Controller
    {
        public IAttatcheFileRepository attatcheFileRepository;
        public IAssignmentRepository assignmentRepository;
        public AttachmentFile(IAttatcheFileRepository attatcheFileRepository,IAssignmentRepository assignmentRepository) {
            this.attatcheFileRepository = attatcheFileRepository;
            this.assignmentRepository = assignmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DeleteFileAssignment(int fileID, int AID)
        {
            attatcheFileRepository.deleteFile(fileID);
            return RedirectToAction("UpdateAssignment", "Assignment", new {AID = AID});
        }
       
    }
}
