using Microsoft.AspNetCore.SignalR;

namespace PlatformService.Models
{
    public class BroadcastHub : Hub<IHubClients>
    {
    }
}
