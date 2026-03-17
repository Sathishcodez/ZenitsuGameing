using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenitsuGameing.Models
{
    public class Company
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? PostalCode { get; set; }
        public long? PhoneNumber { get; set; }
    }
}
