namespace CourseAPI.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository    _courseRepository;
        private readonly IStudentRepository   _studentRepository;
        private readonly ICourseDayRepository _courseDayRepository;

        public CourseService(ICourseRepository courseRepository, IStudentRepository studentRepository, ICourseDayRepository courseDayRepository)
        {
            _courseRepository    = courseRepository;
            _studentRepository   = studentRepository;
            _courseDayRepository = courseDayRepository;
        }
        public async Task AddCourseAsync(CourseDTO createCourseDTO)
        {
            if (string.IsNullOrWhiteSpace(createCourseDTO.CourseName))
            {
                throw new ArgumentNullException("Khóa học không thể trônga");
            }

            if(createCourseDTO.Tuition < 100000 || createCourseDTO.Tuition > 10000000)
            {
                throw new ArgumentException("Học phí phải lớn hơn 100000 và nhỏ hơn 10000000");
            }
            
            var newCourse = new Course
            {
                CourseName  = createCourseDTO.CourseName,
                Description = createCourseDTO.Description,
                Tuition     = createCourseDTO.Tuition,
                StartDay    = createCourseDTO.StartDay,
                EndDay      = createCourseDTO.EndDay,
            };

            await _courseRepository.AddCourseAsync(newCourse);
        }

        public async Task<int> CalculateRevenueAsync(int month, int year)
        {
            var courses = await _courseRepository.GetAllCourseAsync();
            var revenue = 0;
            foreach (var c in courses)
            {
                if(c.StartDay.Month == month && c.EndDay.Year == year)
                {
                    var student = await _studentRepository.CountByCourseIdAsync(c.CourseId);
                    revenue += student * c.Tuition;
                }
            }
            return revenue;
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var existingCourse = await _courseRepository.GetCourseByIdAsync(courseId);
            if (existingCourse == null)
            {
                throw new ArgumentException("Khóa học không tồn tại");
            }
            await _courseRepository.DeleteCourseAsync(existingCourse);
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            return await _courseRepository.GetAllCourseAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await _courseRepository.GetCourseByIdAsync(courseId);
        }

        public async Task UpdateCourseAsync(CourseDTO updateCourseDTO)
        {
            var courseId = updateCourseDTO.CourseId;
            var existingCourse = await _courseRepository.GetCourseByIdAsync(courseId);
            if (existingCourse == null)
            {
                throw new ArgumentException("Khóa học không tồn tại");
            }
            existingCourse.CourseName = updateCourseDTO.CourseName;
            existingCourse.Description = updateCourseDTO.Description;
            existingCourse.Tuition = updateCourseDTO.Tuition;
            existingCourse.StartDay = updateCourseDTO.StartDay;
            existingCourse.EndDay = updateCourseDTO.EndDay;
            await _courseRepository.UpdateCourseAsync(existingCourse);
        }
    }
}
