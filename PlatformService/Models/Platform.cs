using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    //public class Platform
    //{
    //    [Key]
    //    [Required]
    //    public int Id { get; set; }

    //    [Required]
    //    public string Name { get; set; }

    //    [Required]
    //    public string Publisher { get; set; }

    //    [Required]
    //    public string Cost { get; set; }
    //}

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string Cityname { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}