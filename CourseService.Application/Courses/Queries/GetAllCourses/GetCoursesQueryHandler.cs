using AutoMapper;
using CourseService.Application.Common.Exceptions;
using CourseService.Application.Common.Interfaces;
using CourseService.Application.Courses.DTOs;
using CourseService.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Application.Courses.Queries.GetAllCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IList<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(ICourseRepository courseRepository, 
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<IList<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var res = await _courseRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IList<Course>, IList<CourseDto>>(res);
        }
    }
}
