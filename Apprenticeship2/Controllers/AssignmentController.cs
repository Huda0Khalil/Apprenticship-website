using Apprenticeship2.Data;
using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Apprenticeship2.Helper;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Apprenticeship2.Controllers
{
    
    public class AssignmentController : Controller
    {
        IAssignmentRepository assignmentRepository;
        IObjectiveRepository objectiveRepository;
        IAttatcheFileRepository attatcheFileRepository;
        ITrainingRepository trainingRepository;
        IStudentRepository studentRepository;
        public AssignmentController(IAssignmentRepository assignmentRepository, IObjectiveRepository objectiveRepository, IAttatcheFileRepository attatcheFileRepository, ITrainingRepository trainingRepository, IStudentRepository studentRepository)
        {
            this.assignmentRepository = assignmentRepository;
            this.objectiveRepository = objectiveRepository;
            this.attatcheFileRepository = attatcheFileRepository;
            this.trainingRepository = trainingRepository;
            this.studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult AddAsignment( InserAssignmentDTO inserAssignmentDTO)
        {
            ViewBag.trainingID = inserAssignmentDTO.trainingID;
            ViewBag.objectives = objectiveRepository.GetAllTrainingObjectives(inserAssignmentDTO.trainingID);
            return View(inserAssignmentDTO);
        }
        [Authorize(Roles = "TEAMLEADER")]
        [HttpPost]
        public  IActionResult insertAssignment(InserAssignmentDTO inserAssignmentDTO)
        { if(ModelState.IsValid)
            {
                assignmentRepository.AddAssignment(inserAssignmentDTO);
                //string stuemail = studentRepository.GetEmailStudent(inserAssignmentDTO.trainingID);
                //SendEmail.newEmail(stuemail, "This email is to let you konw there is a new assignment assigned to you", inserAssignmentDTO.assignmentTitle);
                return RedirectToAction("showAssignment", new { TID = inserAssignmentDTO.trainingID });
            }
            else
            {
                return RedirectToAction("AddAsignment","Assignment",  inserAssignmentDTO  );
            }
            
            
           
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult showAssignment(int TID)
        {
            ViewBag.TID = TID;
            ViewBag.training = trainingRepository.GetOneTraining(TID);
            ViewBag.Ass = assignmentRepository.GetTrainingAssignments(TID);
            return View();
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult UpdateAssignment(int AID)
        {
            Assignment assignment = assignmentRepository.GetAssignment(AID);
            ViewBag.trainingobjectives = objectiveRepository.GetAllTrainingObjectives(assignment.trainingId);
            ViewBag.files =  attatcheFileRepository.GetAssignmentFile(AID);
            return View(assignmentRepository.AssignmentToUpdateAssignmentDTO(assignment));
        }
        [Authorize (Roles ="STUDENT,TEAMLEADER, UNIVERSITYSUPERVISOR")]
        public FileStreamResult  GetFile(long attachmentId)
        {
            return attatcheFileRepository.GetFile(attachmentId);
            
        }
       
        [Authorize(Roles = "TEAMLEADER")]
        [HttpPost]
        public IActionResult updateOneAssignment(UpdateAssignmentDTO upaDTO)
        {
            assignmentRepository.updateAssignmentRecord(upaDTO);


            return RedirectToAction("showAssignment", new { TID = upaDTO.trainingId});
        }
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult DeleteAssignment(int AID, int TrainingId)
        {
            assignmentRepository.DeletAssignment(AID);
            return RedirectToAction("showAssignment", new {TID = TrainingId });
        }
        
        [Authorize(Roles = "TEAMLEADER")]
        public IActionResult UploadFile(IFormFile upFile)
        {
            /*fileAttatchment x0 = new fileAttatchment();
            if(upFile.Length > 0)
            {
                Stream st = upFile.OpenReadStream();
                using (BinaryReader br = new BinaryReader(st))
                {
                    var byteFile = br.ReadBytes((int)st.Length);
                    x0.file = byteFile;
                } 
                x0.name = upFile.FileName;
                x0.contentType = upFile.ContentType;
                context.fileAttatchments.Add(x0);
                context.SaveChanges();
            }*/
            return View();
        }
        
    }
}
