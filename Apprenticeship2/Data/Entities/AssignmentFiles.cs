namespace Apprenticeship2.Data.Entities
{
    public class AssignmentFiles
    {
        public int assignmentFilesId { get; set; }
        public string name { get; set; }
        public string contentType { get; set; }
        public byte[] file { get; set; }
        public Assignment Assignment { get; set; }
        public int AssignmentId { get; set; }
        
    }
}
