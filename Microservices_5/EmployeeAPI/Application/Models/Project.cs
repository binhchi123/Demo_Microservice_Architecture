namespace EmployeeAPI.Application.Models
{
    public class Project
    {
        [Key]
        public int    ProjectId   { get; set; }
        [StringLength(10)]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Note        { get; set; }

        [JsonIgnore]
        public ICollection<Assignment>? Assignments { get; set; }
    }
}
