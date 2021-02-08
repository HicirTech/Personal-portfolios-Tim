using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace ServerBackend.Hubs
{
    public class LoginChecker : Hub
    {
        private static int counter = 0;
        public LoginChecker()
        {

        }

        public override Task OnConnectedAsync()
        {
            counter++;
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? e)
        {
            //custom logic here
            counter--;            
            return base.OnDisconnectedAsync(e);
        }

        public async Task onLoad()
        {

            await Clients.Caller.SendAsync("onLoadConfirm", counter);

        }


    }
}
