using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SmartMirror.Hubs
{
    public class MainHub : Hub
    {
        public async Task BringThing()
        {
            System.Diagnostics.Debug.WriteLine("bring Thing");
        }

        public async Task ToCheckout()
        {
            System.Diagnostics.Debug.WriteLine("to checkout");
        }

        public async Task ComeUp()
        {
            System.Diagnostics.Debug.WriteLine("come up");
        }
    }
}
