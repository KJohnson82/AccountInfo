using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountInfo.Data.Models
{
    public class Loctype
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Required]
        public string LoctypeName { get; set; }

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
