using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountInfo.Data.Models
{
    //public class Loctype
    //{
    //    [Column("Id")]
    //    [Key]
    //    public int Id { get; set; }

    //    [Required]
    //    [MaxLength(50)]
    //    public string LoctypeName { get; set; }

    //    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    //}

    public enum Loctype
    {
        Corporate = 1,
        MetalMart = 2,
        ServiceCenter = 3,
        Plant = 4,
        Other = 5
    }
}
