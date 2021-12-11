using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Models
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
