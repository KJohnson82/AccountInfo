namespace AccountInfo.Shared.DTOs
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string LocName { get; set; } = string.Empty;
        public int? LocNum { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? Email { get; set; }
        public string? Hours { get; set; }
        public int Loctype { get; set; }
        //public Loctype Loctype { get; set; }
        public string? AreaManager { get; set; }
        public string? StoreManager { get; set; }
        public DateTime? RecordAdd { get; set; }
        public bool Active { get; set; } = true;

        // Flattened related data
        public string? LoctypeName { get; set; }

        public List<DepartmentDto> Departments { get; set; } = new List<DepartmentDto>();
        //public List<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
    }
}
