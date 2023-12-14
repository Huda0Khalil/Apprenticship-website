using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apprenticeship2.Controllers
{
    [Authorize(Roles = "ADMIN")]

    public class TrainingController : Controller
    {
        ITrainingRepository trainingRepository;
        IStudentRepository studentRepository;
        IUniversitySupervisorRepository universitySupervisorRepository;
        ITeamLeaderRepository teamLeaderRepository;
        IObjectiveRepository objectRepository;
        public TrainingController(
            ITrainingRepository trainingRepository,
            IStudentRepository studentRepository,
            IUniversitySupervisorRepository universitySupervisorRepository,
            ITeamLeaderRepository teamLeaderRepository,
            IObjectiveRepository objectRepository) 
        { 
            this.trainingRepository = trainingRepository;
            this.studentRepository = studentRepository;
            this.universitySupervisorRepository = universitySupervisorRepository;
            this.teamLeaderRepository = teamLeaderRepository;
            this.objectRepository = objectRepository;
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Index()
        {
            ViewBag.trainings = trainingRepository.GetAllTraining();
            return View();
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Add(InsertTrainingDTO trainingDTO)
        {
            ViewBag.students = studentRepository.GetAllStudents();
            ViewBag.supervisors = universitySupervisorRepository.GetAllSupervisor();
            ViewBag.teamLeaders = teamLeaderRepository.GetAllLeaders();
            ViewBag.objectives = objectRepository.GetAllObjectives();


            return View(trainingDTO);
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult insertTraining(InsertTrainingDTO trainingDTO) {
            if(ModelState.IsValid)
            {
                trainingRepository.createTraining(trainingDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Add", trainingDTO);
            }
           
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult update(int TrainingId)
        {
            ViewBag.students = studentRepository.GetAllStudents();
            ViewBag.supervisors = universitySupervisorRepository.GetAllSupervisor();
            ViewBag.teamLeaders = teamLeaderRepository.GetAllLeaders();
            ViewBag.objectives = objectRepository.GetAllObjectives();
            //ViewBag.trainingObjective = trainingRepository.GetOT(TrainingId);
            return View(trainingRepository.trainingToUpdateTrainingDTO(TrainingId));
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult updateTraining(updateTrainingDTO updateTrainingDTO)
        {
            trainingRepository.EditTrainingRecord(updateTrainingDTO);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult delete(int TrainingId)
        {
            trainingRepository.deleteTraining(TrainingId);

            return RedirectToAction("Index");
        }
        
    }
}
//trainingRepository.GetOneTraining(TrainingId)