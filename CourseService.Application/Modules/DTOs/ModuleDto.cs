namespace CourseService.Application.Modules.DTOs
{
    public class ModuleDto
    {
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public string Title { get; set; } = string.Empty;

        public int OrderIndex { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
