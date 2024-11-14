namespace EmployeeAPI.DTOs
{
    public class EmployeeDTO
    {
        public int      EmployeeId        { get; set; }
        public string   Name              { get; set; }
        public DateTime Birthday          { get; set; }
        public string   PhoneNumber       { get; set; }
        public string   Address           { get; set; }
        public string   Email             { get; set; }
        public int      SalaryCoefficient { get; set; }
        public int      ProjectId         { get; set; } 
        public int      WorkHour          { get; set; }
    }
}
