namespace Click2Rent.WPFClient.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public string CreatedByUser { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateString { get; set; } = string.Empty;
        public int ModifiedByUserId { get; set; }
        public string ModifiedByUser { get; set; } = string.Empty;

        public User(){}

        public User(string username, DateTime createdDate, int createdByUserId, DateTime modifiedDate, int modifiedByUserId)
        {
            Username = username;
            CreatedDate = createdDate;
            CreatedByUserId = createdByUserId;
            ModifiedDate = modifiedDate;
            ModifiedByUserId = modifiedByUserId;
        }
    }
}
