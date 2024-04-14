using System.ComponentModel.DataAnnotations;
using task_management_api.entities;

namespace task_management_api.models
{
    public class UserDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string PasswordSalt { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        public string ProfilePicture { get; set; }
    }
}
