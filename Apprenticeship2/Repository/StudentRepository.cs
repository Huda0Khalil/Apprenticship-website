using Apprenticeship2.Data;
using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext context;
        private readonly UserManager<Person> _userManager;

        public StudentRepository(ApplicationDbContext context, UserManager<Person> _userManager)
        {
            this.context = context;
            this._userManager = _userManager;
        }
        public List<Student> GetAllStudents()
        {
           return context.students.Include(s => s.University).ToList();
        }
        public async Task addStudent(Student stu, string password)
        {
            var user = CreateUser();
            user.FirstName = stu.FirstName;
            user.SecondName = stu.SecondName;
            user.ThirdName = stu.ThirdName;
            user.LastName = stu.LastName;
            user.Email = stu.Email;
            user.UserName = stu.Email.ToUpper();
            user.NormalizedEmail = stu.Email.ToUpper();
            user.NormalizedUserName = stu.Email.ToUpper();
            user.EmailConfirmed = true;
            user.Address = stu.Address;
            user.Age = stu.Age;
            user.Major = stu.Major;
            user.GPA = stu.GPA;
            user.CompletedHours = stu.CompletedHours;
            user.PhoneNumber = stu.PhoneNumber;
            user.universityId = stu.universityId;
            var result = await _userManager.CreateAsync(user, password );

        }
        public Student selectOne(string stu)
        {
            var student = context.students.Where(s => s.Id == stu).SingleOrDefault();
            return student;
        }
        public void updateStudentRecord(Student stu)
        {
            var user = context.students.Where(s => s.Id == stu.Id).SingleOrDefault();
            user.FirstName = stu.FirstName;
            user.SecondName = stu.SecondName;
            user.ThirdName = stu.ThirdName;
            user.LastName = stu.LastName;
            user.Email = stu.Email;
            user.Address = stu.Address;
            user.Age = stu.Age;
            user.Major = stu.Major; 
            user.CompletedHours = stu.CompletedHours;
            user.GPA = stu.GPA;
            user.PhoneNumber= stu.PhoneNumber;
            user.universityId = stu.universityId;
            context.SaveChanges();
        }
        public void deleteStudent(string stu)
        {
            Student student = selectOne(stu);
            context.students.Remove(student);
            context.SaveChanges();
        }
        public List<Training> TeamLeaderStudents(string leaderId)
        {
            return context.trainings.Include(x => x.teamLeader).Include(x => x.student).ThenInclude(x => x.University).Where(x => x.teamLeaderId == leaderId).ToList();
        }
        public List<Training> SupervisorStudents(string supervisorId)
        {
            return context.trainings.Include(x => x.supervisor).Include(x => x.student).ThenInclude(x => x.University).Where(x => x.supervisorId == supervisorId).ToList();

        }
        public string GetEmailStudent(int TID)
        {
          var stu= context.trainings.Include(x => x.student).Where(x => x.TrainingId ==  TID).FirstOrDefault();
            return stu.student.Email;
        }

        private Student CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Student>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Person)}'. " +
                    $"Ensure that '{nameof(Person)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        
    }
}
