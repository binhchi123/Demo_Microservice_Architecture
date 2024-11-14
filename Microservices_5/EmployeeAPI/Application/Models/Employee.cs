namespace EmployeeAPI.Application.Models
{
    public class Employee
    {
        [Key]
        public int               EmployeeId        { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string            Name              { get; set; }

        [Range(typeof(DateTime), "1970-01-01",     "2000-12-31")]
        public DateTime          Birthday          { get; set; }
        public string            PhoneNumber       { get; set; }
        public string            Address           { get; set; }
        public string            Email             { get; set; }
        public int               SalaryCoefficient { get; set; }

        [JsonIgnore]
        public ICollection<Assignment>? Assignments { get; set; }
    }
}
