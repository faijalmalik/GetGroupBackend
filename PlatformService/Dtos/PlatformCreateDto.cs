using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    //public class PlatformCreateDto
    //{
    //    [Required]
    //    public string Name { get; set; }

    //    [Required]
    //    public string Publisher { get; set; }

    //    [Required]
    //    public string Cost { get; set; }
    //}

    public class EmployeeCreateDTO
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        public string Company { get; set; }
        public string Cityname { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}