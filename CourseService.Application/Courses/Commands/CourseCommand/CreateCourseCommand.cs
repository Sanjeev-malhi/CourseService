using MediatR;

namespace CourseService.Application.Courses.Commands.CourseCommand
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Decimal Price { get; set; }
    }
}
