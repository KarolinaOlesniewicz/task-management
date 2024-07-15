using System.Runtime.Serialization;

namespace task_management_api.exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a request is considered invalid by the server.
    /// This typically results in a 400 Bad Request HTTP status code.
    /// </summary>
    public class BadRequestException : Exception
    {
        /// <summary>
        /// Gets the HTTP <see cref="StatusCode"/> associated with this exception, which is always 400 (Bad Request).
        /// </summary>
        public int StatusCode { get; } = 400;

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains why the request is considered bad.</param>
        public BadRequestException(string? message) : base(message)
        {
        }
    }
}