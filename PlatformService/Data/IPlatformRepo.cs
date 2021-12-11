using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Employee> GetAllPlatforms();
        Employee GetPlatformById(int id);
        void CreatePlatform(Employee plat);
    }
}