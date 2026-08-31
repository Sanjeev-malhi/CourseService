using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Application.Courses.Commands.DeleteCourse
{
    public record DeleteCourseCommand(Guid Id) : IRequest<Unit>;
}
