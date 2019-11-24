using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStatedWithSignalR.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task Notify()
        {
            await Clients.All.SendAsync("Notify");
        }
    }
}
