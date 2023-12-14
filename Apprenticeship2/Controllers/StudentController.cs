using Apprenticeship2.Data.DTO;
using Apprenticeship2.Data.Entities;
using Apprenticeship2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Apprenticeship2.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        IStudentRepository studentRepository;
        IUniversityRepository universityRepository;
        IAssignmentRepository assignmentRepository;
        IAttatcheFileRepository attatcheFileRepository;
        IReportRepository reportRepository;
        ITrainingRepository trainingRepository;
        public StudentController(IStudentRepository studentRepository,
            IUniversityRepository universityRepository,
            IAssignmentRepository assignmentRepository,
            IAttatcheFileRepository attatcheFileRepository,
            IReportRepository reportRepository,
            ITrainingRepository trainingRepository)
        {
            this.studentRepository = studentRepository;
            this.universityRepository = universityRepository;
            this.assignmentRepository = assignmentRepository;
            this.attatcheFileRepository = attatcheFileRepository;
            this.reportRepository = reportRepository;
            this.trainingRepository = trainingRepository;
        }
        [Authorize(Roles ="STUDENT")]
        public IActionResult Index()
        {
            string StudentId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.AssignmentsCount = assignmentRepository.countAssignments(StudentId);
            ViewBag.finishedAssignments = assignmentRepository.countFinishedAssignments(StudentId);
            ViewBag.currentAssignments = assignmentRepository.countCurrentAssignment(StudentId);
            ViewBag.Assignments = assignmentRepository.currentAssignments(StudentId);
            ViewBag.Training = trainingRepository.GetStudentTraining(StudentId);
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult StudentsPage()
        {
            ViewBag.studs = studentRepository.GetAllStudents();
            return View();
        }
        [Authorize(Roles = "ADMIN")]
        public IActionResult Add(InsertStudentDTO stu)
        {
            ViewBag.universities = universityRepository.AllUniversities();
            return View(stu);
        }

        [Authorize(Roles = "ADMIN")]

        public async Task<IActionResult> insertStudent(InsertStudentDTO stu)
        {
            if(ModelState.IsValid)
            {
                Student student = new Student();
                student.FirstName = stu.firstName;
                student.SecondName = stu.secondName;
                student.ThirdName = stu.thirdName;
                student.LastName = stu.lastName;
                student.GPA = stu.GPA;
                student.CompletedHours = stu.CompletedHours;
                student.Email = stu.studentEmail;
                student.Address = stu.Address;
                student.Age = stu.Age;
                student.Major = stu.Major;
                student.universityId = stu.universityId;
                student.PhoneNumber = stu.PhoneNumber;
                if (stu.ConfirmPassword == stu.password)
                {
                    await studentRepository.addStudent(student, stu.password);

                }
                return RedirectToAction("StudentsPage");
            }
            else
            {
                return RedirectToAction("Add", stu);
            }
            


        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult Update(string stu)
        {
            ViewBag.universities = universityRepository.AllUniversities();

            return View(studentRepository.selectOne(stu));
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult updateStudent(Student student)
        {
            studentRepository.updateStudentRecord(student);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "ADMIN")]

        public IActionResult delete(string stu)
        {
            studentRepository.deleteStudent(stu);
            return RedirectToAction("StudentsPage");
        }
        [Authorize(Roles = "STUDENT")]

        public IActionResult StudentAssignment()
        {
            string StudentID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            ViewBag.assignments = assignmentRepository.GetStudentAssignments(StudentID);
          //  ViewBag.Files = attatcheFileRepository.
            return View();
        }

        public IActionResult ShowOneAssignment(int assignmentID)
        {
          //  ViewBag.files = attatcheFileRepository.GetAssignmentFile(assignmentID);
            //ViewBag.OneAssignment = assignmentRepository.GetOneStudentAssignment(assignmentID);
           ViewBag.Reports = reportRepository.GetAssignmentReports(assignmentID);
            return View(assignmentRepository.GetOneStudentAssignment(assignmentID));
        }
    }
}
