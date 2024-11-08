namespace StudentAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository   _classRepository;

        public StudentService(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository   = classRepository;
        }
        public async Task AddStudentAsync(StudentDTO createStudentDTO)
        {
            var cl = await _studentRepository.CountByClassIdAsync(createStudentDTO.ClassId);
            if (cl >= 20)
            {
                throw new ArgumentException("Mỗi lớp có tối đa 20 học sinh");
            }
            if (string.IsNullOrWhiteSpace(createStudentDTO.FullName))
            {
                throw new ArgumentNullException("Họ và tên không để trống");
            }
            if (createStudentDTO.Birthday < new DateTime(2001, 1, 1) || createStudentDTO.Birthday > new DateTime(2013, 12, 31))
            {
                throw new ArgumentNullException("Ngày sinh phải từ năm 2001 đến 2013.");
            }
            var newStudent = new Student()
            {
                ClassId  = createStudentDTO.ClassId,
                FullName = createStudentDTO.FullName,
                Birthday = createStudentDTO.Birthday,
                Address  = createStudentDTO.Address,
            };
            await _studentRepository.AddStudentAsync(newStudent);
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var existingStudent = await _studentRepository.GetStudentByIdAsync(studentId);
            if (existingStudent == null)
            {
                throw new ArgumentNullException("Học sinh không tồn tại");
            }
            await _studentRepository.DeleteStudentAsync(existingStudent);
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _studentRepository.GetAllStudentAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.GetStudentByIdAsync(studentId);
        }

        public async Task MoveClassAsync(int studentId, int newClassId)
        {
            // Lấy thông tin học sinh và lớp cũ
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
            {
                throw new Exception("Học sinh không tồn tại.");
            }

            var currentClass = await _studentRepository.GetClassByIdAsync(student.ClassId);
            if (currentClass == null)
            {
                throw new Exception("Lớp cũ không tồn tại.");
            }

            // Lấy thông tin lớp mới
            var newClass = await _studentRepository.GetClassByIdAsync(newClassId);
            if (newClass == null)
            {
                throw new Exception("Lớp mới không tồn tại.");
            }

            // Kiểm tra sĩ số lớp mới có quá 20 học sinh không
            if (newClass.Students.Count >= 20)
            {
                throw new Exception("Lớp mới đã đủ sĩ số.");
            }

            // Cập nhật thông tin học sinh
            student.ClassId = newClassId;

            // Cập nhật sĩ số lớp cũ và lớp mới
            currentClass.NumberOfStudent--;
            newClass.NumberOfStudent++;

            // Cập nhật cơ sở dữ liệu
            await _studentRepository.UpdateStudentAsync(student);
            await _classRepository.UpdateClassAsync(currentClass);
            await _classRepository.UpdateClassAsync(newClass);
        }

        public async Task UpdateStudentAsync(StudentDTO updateStudentDTO)
        {
            var studentId = updateStudentDTO.StudentId;
            var existingStudent = await _studentRepository.GetStudentByIdAsync(studentId);
            if (existingStudent == null)
            {
                throw new ArgumentNullException("Học sinh không tồn tại");
            }
            if (updateStudentDTO.Birthday < new DateTime(2001, 1, 1) || updateStudentDTO.Birthday > new DateTime(2013, 12, 31))
            {
                throw new ArgumentNullException("Ngày sinh phải từ năm 2001 đến 2013.");
            }
            existingStudent.ClassId  = updateStudentDTO.ClassId;
            existingStudent.FullName = updateStudentDTO.FullName;
            existingStudent.Birthday = updateStudentDTO.Birthday;
            existingStudent.Address  = updateStudentDTO.Address;
            await _studentRepository.UpdateStudentAsync(existingStudent);
        }
    }
}
