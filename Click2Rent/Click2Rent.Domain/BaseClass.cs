namespace Click2Rent.Domain
{
    public class BaseClass
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool Locked { get; set; }
        public bool Visible { get; set; } = true;
        public int Version { get; set; }
        public bool IsDeleted { get; set; }
    }
}
