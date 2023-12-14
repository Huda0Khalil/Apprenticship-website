namespace Apprenticeship2.Data.Entities
{
    public class TeamLeader : Person
    {
        public Company Company { get; set; }    
        public int companyId { get; set; }
        public List<Training> training { get; set; }
    }
}
