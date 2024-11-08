namespace StudentAPI.Application.IService
{
    public interface IClassService
    {
        Task<List<Class>> GetAllClassAsync();
        Task<Class> GetClassByIdAsync(int classId);
        Task AddClassAsync(ClassDTO createClassDTO);
        Task UpdateClassAsync(ClassDTO updateClassDTO);
        Task DeleteClassAsync(int classId);
    }
}
