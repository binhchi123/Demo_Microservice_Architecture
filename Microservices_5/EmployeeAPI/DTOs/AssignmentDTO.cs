namespace EmployeeAPI.DTOs
{
    public class AssignmentDTO
    {
        public int AssignmentId { get; set; }
        public int EmployeeId   { get; set; }
        public int ProjectId    { get; set; }
        public int WorkHour     { get; set; }
    }
}
