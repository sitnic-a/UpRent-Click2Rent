using System.ComponentModel.DataAnnotations;

namespace Click2Rent.Domain
{
    public class User : BaseClass
    {
        public User(){}
        public User(string username)
        {
            Username = username;
        }
        public User(int id, string username)
        {
            Id= id;
            Username= username;
        }

        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
    }
}
