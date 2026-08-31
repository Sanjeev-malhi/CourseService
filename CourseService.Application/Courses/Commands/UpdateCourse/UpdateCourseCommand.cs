using MediatR;

namespace CourseService.Application.Courses.Commands.UpdateCourse
{
    public record UpdateCourseCommand(Guid Id, string Name, string Description, decimal Price, bool IsPublished) 
        : IRequest<Unit>;
}
