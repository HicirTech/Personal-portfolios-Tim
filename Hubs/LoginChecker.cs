using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Collections;

namespace ServerBackend.Hubs
{
    public class LoginChecker : Hub
    {
        private static HashSet<string> currentUsers = new HashSet<string>();

        public LoginChecker()
        {

        }

        public override Task OnConnectedAsync()
        {
            var current = Context.ConnectionId;
            if (current != null)
            {
                currentUsers.Add(Context.ConnectionId);

            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? e)
        {
            //custom logic here
            currentUsers.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(e);
        }

        public async Task onLoad()
        {

            await Clients.Caller.SendAsync("onLoadConfirm", currentUsers.Count);

            await Clients.Others.SendAsync("updateCount", currentUsers.Count);



        }


    }
}
