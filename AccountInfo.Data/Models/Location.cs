
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountInfo.Data.Models
{
    public class Location
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? LocName { get; set; }

        [Required]
        public int LocNum { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        [StringLength(3)]
        public string? State { get; set; }

        [Required]
        [Column(TypeName = "TEXT")]
        public string? Zipcode { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [StringLength(15)]
        public string? FaxNumber { get; set; }

        [Column("Email")]
        [EmailAddress]
        [StringLength(60)]
        public string? Email { get; set; }

        public string? Hours { get; set; }

        // Foreign key
        [Required]
        public int? LoctypeId { get; set; }

        public string? AreaManager { get; set; }

        public string? StoreManager { get; set; }
        public bool? Active { get; set; } = true;

        [JsonIgnore]
        public DateTime? RecordAdd { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Loctype? LocationType { get; set; }

        public List<InternetAccount> InternetAccounts { get; set; } = new();

        public PhoneAccount? PhoneAccount { get; set; }
    }
}
