namespace AccountInfo.Shared.Enums
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
