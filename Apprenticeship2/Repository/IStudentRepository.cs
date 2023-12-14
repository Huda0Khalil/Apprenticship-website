using Apprenticeship2.Data.Entities;

namespace Apprenticeship2.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public Task addStudent(Student stu, string password);
        public Student selectOne(string stu);
        public void updateStudentRecord(Student stu);
        public void deleteStudent(string stu);
        public List<Training> SupervisorStudents(string supervisorId);
        public List<Training> TeamLeaderStudents(string leaderId);
        public string GetEmailStudent(int TID);
    }
}
