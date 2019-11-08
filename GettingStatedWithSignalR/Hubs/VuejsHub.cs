using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStatedWithSignalR.Hubs
{
    public class VuejsHub : Hub
    {
        public async Task Add(string name)
        {
            //event
            await Clients.All.SendAsync("AddEvent", name);
        }
    }
}

