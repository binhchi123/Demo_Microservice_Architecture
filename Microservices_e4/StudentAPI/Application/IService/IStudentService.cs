﻿namespace StudentAPI.Application.IService
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task AddStudentAsync(StudentDTO createStudentDTO);
        Task UpdateStudentAsync(StudentDTO updateStudentDTO);
        Task DeleteStudentAsync(int studentId);
        Task MoveClassAsync(int studentId, int newClassId);
    }
}
