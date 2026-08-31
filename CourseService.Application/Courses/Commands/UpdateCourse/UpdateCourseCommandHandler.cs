using AutoMapper;
using CourseService.Application.Common.Exceptions;
using CourseService.Application.Common.Interfaces;
using MediatR;

namespace CourseService.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCourseCommandHandler(ICourseRepository repository, IMapper mapper, IUnitOfWork work)
        {
            _courseRepository = repository;
            _mapper = mapper;
            _unitOfWork = work;
        }
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if(course is null)
            {
                throw new NotFoundException(nameof(course), request.Id);
            }
            _mapper.Map(request, course);
            course.LastModified = DateTime.UtcNow;
            _courseRepository.UpdateAsync(course);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
