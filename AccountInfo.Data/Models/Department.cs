using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountInfo.Data.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string DeptName { get; set; }
        [Required]
        public int LocationId { get; set; }
        [StringLength(60)]
        public string? DeptManager { get; set; }
        public bool Active { get; set; } = true;
        public DateTime? RecordAdd { get; set; }

        public virtual Location? DeptLocation { get; set; }



    }
}
