using CourseService.Application.Common.Exceptions;
using CourseService.Application.Common.Interfaces;
using CourseService.Domain.Entites;
using MediatR;

namespace CourseService.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCourseCommandHandler(ICourseRepository repository, 
                                         IUnitOfWork work)
        {
            _courseRepository = repository;
            _unitOfWork = work;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if(course is null)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }

            _courseRepository.DeleteAsync(course);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
