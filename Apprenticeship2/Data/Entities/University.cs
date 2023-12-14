namespace Apprenticeship2.Data.Entities
{
    public class University
    {
        public int universityId {  get; set; }
        public string universityName { get; set;}
        public string universityLocation { get; set;}
        public List<UniversitySupervisor> universitySupervisors { get; set; }
        public List<Student> students { get; set; }

    }
}
