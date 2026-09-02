namespace CourseService.Application.Common.Interfaces
{
    public interface IModuleRepository
    {
        Task AddAsync(Domain.Entites.Modules module, CancellationToken cancellationToken);

        void UpdateAsync(Domain.Entites.Modules module);

        void DeleteAsync(Domain.Entites.Modules module);

        Task<Domain.Entites.Modules> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Domain.Entites.Modules>> GetByCourseIdAsync(Guid courseId, CancellationToken cancellationToken);
    }
}
