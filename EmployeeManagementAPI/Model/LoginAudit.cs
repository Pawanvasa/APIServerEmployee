using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Model
{
    public partial class LoginAudit
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Ipaddress { get; set; }
        public string? AuditStatus { get; set; }
        public string? AudiType { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? Description { get; set; }
    }
}
