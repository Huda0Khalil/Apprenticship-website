namespace Apprenticeship2.Data.Entities
{
    public class UniversitySupervisor : Person
    {
        public List<Training> trainings {  get; set; }
        public University university { get; set; }
        public int universityId { get; set; }
    }
}
