using CourseService.Domain.Entites;

namespace CourseService.Application.Common.Interfaces
{
    public interface ICourseRepository
    {
        Task AddAsync(Course course, CancellationToken cancellationToken);

        void UpdateAsync(Course course);

        void DeleteAsync(Course course);

        Task<Course> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Course>> GetAllAsync(CancellationToken cancellationToken);
    }
}
