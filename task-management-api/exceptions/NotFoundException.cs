namespace task_management_api.exceptions
{
    public class NotFoundException : Exception
    {
        public int StatusCode = 404;
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}
