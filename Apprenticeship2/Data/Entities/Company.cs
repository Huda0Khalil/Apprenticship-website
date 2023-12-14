using System.ComponentModel.DataAnnotations;

namespace Apprenticeship2.Data.Entities
{
    public class Company
    {
        [Required]
        public int companyId {  get; set; }
        [Required]
        public string companyName { get; set; }
        [Required]
        public string companyLocation { get; set; }
        [Required]
        public string companyEmail { get; set; }
        [Required]
        public string companyPhone { get; set; }
        public List<TeamLeader> teamLeaders { get; set; }

    }
}
