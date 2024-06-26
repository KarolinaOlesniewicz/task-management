using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_management_wpf.dtos
{
    public class RegisterDto
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
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        public RegisterDto(string firstname,string lastname,string username,string email,string password)
        {
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Email = email;
            PasswordHash = password;
            ProfilePicture = "default";
        }
    }
}

