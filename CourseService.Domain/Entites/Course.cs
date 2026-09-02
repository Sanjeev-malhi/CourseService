namespace CourseService.Domain.Entites
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsPublished { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; }

        public ICollection<Modules> Modules { get; set; } = new List<Modules>();
    }
}
