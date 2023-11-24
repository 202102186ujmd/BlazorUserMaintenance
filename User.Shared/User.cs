using System.ComponentModel.DataAnnotations;

namespace User.Shared
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? CellNumber { get; set; }
        public string? EmailId { get; set; }

    }
}
