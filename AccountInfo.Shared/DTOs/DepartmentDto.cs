using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInfo.Shared.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DeptName { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string? DeptManager { get; set; }
        public bool Active { get; set; } = true;
        public DateTime? RecordAdd { get; set; }
    }
}
