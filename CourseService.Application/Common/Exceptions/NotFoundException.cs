namespace CourseService.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string EntityName, object key)
            : base($"Entity \"{EntityName}\" ({key}) was not found.")
        {
        }
    }
}
