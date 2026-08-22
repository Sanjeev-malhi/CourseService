using System;
using System.Collections.Generic;
using System.Text;

namespace CourseService.Domain.Entites
{
    public class Module
    {
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int OrderIndex { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime LastModified { get; set; }

        public Course Course { get; set; } = null!;
    }
}
