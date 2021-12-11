using PlatformService.Data;
using PlatformService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IPlatformRepo _context;
        private readonly IHubContext<BroadcastHub, IHubClients> _hubContext;

        public NotificationsController(IHubContext<BroadcastHub, IHubClients> hubContext, IPlatformRepo context)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/Notifications/notificationcount
        [Route("notificationcount")]
        [HttpGet]
        public async Task<ActionResult<NotificationCountResult>> GetNotificationCount()
        {
            var count = (from not in _context.GetAllPlatforms()
                         select not).Count();
            NotificationCountResult result = new NotificationCountResult
            {
                Count = count
            };
            return result;
        }

        // GET: api/Notifications/notificationresult
        [Route("notificationresult")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationResult>>> GetNotificationMessage()
        {
            var results = from message in _context.GetAllPlatforms()
                          orderby message.Id descending
                          select new NotificationResult
                          {
                              Name = message.Name,
                              Company = message.Company
                          };
            return results.ToList();
        }

        
    }
    public class NotificationCountResult
    {
        public int Count { get; set; }
    }

    public class NotificationResult
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
