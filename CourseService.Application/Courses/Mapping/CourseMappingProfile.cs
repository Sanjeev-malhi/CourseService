using AutoMapper;
using CourseService.Application.Courses.Commands.UpdateCourse;
using CourseService.Application.Courses.DTOs;
using CourseService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Application.Courses.Mapping
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDto>()
                .ReverseMap();
            CreateMap<UpdateCourseCommand, Course>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
