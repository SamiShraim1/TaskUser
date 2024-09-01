using System.ComponentModel.DataAnnotations;

namespace TaskUser.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; } = false;
    }
}
