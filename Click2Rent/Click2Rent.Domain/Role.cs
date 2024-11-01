using System.ComponentModel.DataAnnotations;

namespace Click2Rent.Domain
{
    public class Role : BaseClass
    {
        public Role(){}
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
