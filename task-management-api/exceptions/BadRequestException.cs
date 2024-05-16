using System.Runtime.Serialization;

namespace task_management_api.exceptions
{
    public class BadRequestException : Exception
    {
        public int StatusCode = 400;
        public BadRequestException(string? message) : base(message)
        {
        }
    }
}