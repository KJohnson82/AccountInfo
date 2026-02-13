using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInfo.Shared.DTOs
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AssignedRole { get; set; }
        public bool? Active { get; set; }
        public DateTime? RecordAdd { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
