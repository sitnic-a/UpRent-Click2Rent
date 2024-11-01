using System.ComponentModel.DataAnnotations.Schema;

namespace Click2Rent.Domain
{
    public class UserRole : BaseClass
    {
        public UserRole(){}
        public UserRole(int id, int userId, int roleId, string? comment = null)
        {
            Id = id;
            UserId = userId;
            RoleId = roleId;
            Comment = comment;
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string? Comment { get; set; } = string.Empty;
    }
}
