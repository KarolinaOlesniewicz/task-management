using System.ComponentModel.DataAnnotations;

namespace task_management_api.entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string? ProfilePicturePath { get; set; }

        public int WorkspacesId { get; set; }

        #region virtuals
        public virtual List<Workspace> Workspaces { get; set; }
        #endregion
    }
}
