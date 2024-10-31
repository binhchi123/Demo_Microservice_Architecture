﻿namespace CourseAPI.Application.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<int> CountByCourseIdAsync(int courseId);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Student student);
        Task<List<Student>> SearchStudentsAsync(string name, string courseName);
    }
}
