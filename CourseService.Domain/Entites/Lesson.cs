using CourseService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Domain.Entites
{
    public class Lesson
    {
        public Guid Id { get; set; }

        public Guid ModuleId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int OrderIndex { get; set; }

        public int  DurationInSeconds { get; set; }

        public string ContextUrl { get; set; } = string.Empty;

        public LessonType Type { get; set; }

        public Module Module { get; set; } = null!;
    }
}
