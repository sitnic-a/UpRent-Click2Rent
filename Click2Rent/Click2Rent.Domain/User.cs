using System.ComponentModel.DataAnnotations;

namespace Click2Rent.Domain
{
    public class User : BaseClass
    {
        public User(){}
        public User(string username, int createdByUserId)
        {
            Username = username;
            CreatedByUserId = createdByUserId;
        }
        public User(int id, string username, int createdByUserId)
        {
            Id= id;
            Username= username;
            CreatedByUserId= createdByUserId;
        }

        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
    }
}
