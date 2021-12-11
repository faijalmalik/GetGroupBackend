using CommandsService.Data;
using CommandsService.SIngalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET5SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public NotificationsController( IHubContext<BroadcastHub, IHubClient> hubContext, ICommandRepo repository)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        // GET: api/Notifications/notificationcount
        [Route("notificationcount")]
        [HttpGet]
        public ActionResult<NotificationCountResult> GetNotificationCount()
        {
            var count = (from not in _repository.GetAllPlatforms()
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
        public ActionResult<List<NotificationResult>> GetNotificationMessage()
        {
            var results = from message in _repository.GetAllPlatforms()
                          orderby message.Id descending
                          select new NotificationResult
                          {
                              Name = message.Name,
                              Company = message.Company
                          };
            return results.ToList();
        }

        // DELETE: api/Notifications/deletenotifications
        //[HttpDelete]
        //[Route("deletenotifications")]
        //public async Task<IActionResult> DeleteNotifications()
        //{
        //    await _repository..ExecuteSqlRawAsync("TRUNCATE TABLE Notification");
        //    await _context.SaveChangesAsync();
        //    await _hubContext.Clients.All.BroadcastMessage();

        //    return NoContent();
        //}
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
