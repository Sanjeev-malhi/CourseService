using CourseService.Application.Common.Exceptions;
using CourseService.Application.Common.Interfaces;
using CourseService.Application.Courses.DTOs;
using CourseService.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Application.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if(course == null)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }
            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                Price = course.Price,
                CreatedOn = course.CreatedOn
            };
        }
    }
}
