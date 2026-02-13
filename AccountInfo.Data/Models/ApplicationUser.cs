using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountInfo.Data.Models
{
    public class ApplicationUser
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AssignedRole { get; set; }
        public bool? Active { get; set; } = true;
        public DateTime? RecordAdd { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
