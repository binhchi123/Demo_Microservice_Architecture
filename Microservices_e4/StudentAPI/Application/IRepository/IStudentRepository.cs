namespace StudentAPI.Application.IRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<Class> GetClassByIdAsync(int classId);
        Task<int> CountByClassIdAsync(int classId);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
    }
}
