using CourseService.Application.Courses.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Application.Courses.Queries.GetAllCourses
{
    public record GetCoursesQuery : IRequest<IList<CourseDto>>;
}
