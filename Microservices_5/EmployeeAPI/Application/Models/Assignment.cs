namespace EmployeeAPI.Application.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId   { get; set; }

        [ForeignKey("Project")]
        public int ProjectId    { get; set; }
        public int WorkHour     { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }

        [JsonIgnore]
        public Project?  Project  { get; set; }
    }
}
