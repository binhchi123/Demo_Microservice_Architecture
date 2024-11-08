namespace StudentAPI.Application.IRepository
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClassAsync();
        Task<Class> GetClassByIdAsync(int classId);
        Task AddClassAsync(Class classes);
        Task UpdateClassAsync(Class classes);
        Task DeleteClassAsync(Class classes);
    }
}
