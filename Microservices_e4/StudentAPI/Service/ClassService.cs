namespace StudentAPI.Service
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task AddClassAsync(ClassDTO createClassDTO)
        {          
            if (string.IsNullOrWhiteSpace(createClassDTO.ClassName))
            {
                throw new ArgumentNullException("Tên lớp không để trống");
            }
            var newClass = new Class()
            {
                ClassId         = createClassDTO.ClassId,
                ClassName       = createClassDTO.ClassName,
                NumberOfStudent = createClassDTO.NumberOfStudent,
            };
            await _classRepository.AddClassAsync(newClass);
        }

        public async Task DeleteClassAsync(int classId)
        {
            var existingClass = await _classRepository.GetClassByIdAsync(classId);
            if (existingClass == null)
            {
                throw new ArgumentNullException("Lớp không tồn tại");
            }
            await _classRepository.DeleteClassAsync(existingClass);
        }

        public async Task<List<Class>> GetAllClassAsync()
        {
            return await _classRepository.GetAllClassAsync();
        }

        public async Task<Class> GetClassByIdAsync(int classId)
        {
            return await _classRepository.GetClassByIdAsync(classId);
        }

        public async Task UpdateClassAsync(ClassDTO updateClassDTO)
        {
            var classId = updateClassDTO.ClassId;
            var existingClass = await _classRepository.GetClassByIdAsync(classId);
            if (existingClass == null)
            {
                throw new ArgumentNullException("Lớp không tồn tại");
            }
            existingClass.ClassName       = updateClassDTO.ClassName;
            existingClass.NumberOfStudent = updateClassDTO.NumberOfStudent;
            await _classRepository.UpdateClassAsync(existingClass);
        }
    }
}
