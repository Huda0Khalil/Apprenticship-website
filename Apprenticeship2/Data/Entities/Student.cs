namespace Apprenticeship2.Data.Entities
{
    public class Student : Person
    {
        public double GPA { get; set; }
        public string Major {  get; set; }
        public int CompletedHours { get; set; }
        public University University { get; set; }
        public int universityId { get; set; }


    }
}
