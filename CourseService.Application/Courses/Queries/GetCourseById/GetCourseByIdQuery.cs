using CourseService.Application.Courses.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Application.Courses.Queries.GetCourseById
{
    public record GetCourseByIdQuery(Guid Id) : IRequest<CourseDto>;
}
