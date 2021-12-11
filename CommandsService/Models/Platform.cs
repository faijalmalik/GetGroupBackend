using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string Cityname { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}