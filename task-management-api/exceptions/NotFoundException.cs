namespace task_management_api.exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a requested resource is not found on the server.
    /// This typically results in a 404 Not Found HTTP status code.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code associated with this exception, which is always 404 (Not Found).
        /// </summary>
        public int StatusCode { get; } = 404;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains why the resource was not found.</param>
        public NotFoundException(string message) : base(message)
        {
            
        }
    }
}
