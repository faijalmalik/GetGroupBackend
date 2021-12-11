using System;
using System.Text.Json;
using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using CommandsService.SIngalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        public void ProcessEvent(string message)
        {
            Console.WriteLine("ProcessEvent");
            var eventType = DetermineEvent(message);
            Console.WriteLine("DetermineEvent"+ eventType);
            switch (eventType)
            {
                case EventType.PlatformPublished:
                    addPlatform(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch(eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> Platform Published Event Detected");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type" + notifcationMessage);
                    return EventType.Undetermined;
            }
        }

        private void addPlatform(string platformPublishedMessage)
        {
            Console.WriteLine("add platfor,m");
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();
                
                var platformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);

                try
                {
                    var plat = _mapper.Map<Employee>(platformPublishedDto);
                    Console.WriteLine("--> Event Received!121321321"+ plat.ToString());
                    if (!repo.ExternalPlatformExists(Convert.ToInt32(plat.Id)))
                    {
                        repo.CreatePlatform(plat);
                        repo.SaveChanges();
                        Console.WriteLine("--> Platform added! teststststst" + plat.Name);

                        //Signal broadcast message 
                        _hubContext.Clients.All.BroadcastMessage();

                        Console.WriteLine("--> msg pass to signalR");
                    }
                    else
                    {
                        Console.WriteLine("--> Platform already exisits...");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platform to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}