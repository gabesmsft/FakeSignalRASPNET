using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

//https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/tutorial-getting-started-with-signalr
//https://docs.microsoft.com/en-us/aspnet/signalr/overview/performance/scaleout-with-redis
//https://docs.microsoft.com/en-us/aspnet/signalr/overview/deployment/using-signalr-with-azure-web-sites

namespace FakeSignalRAspNet
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("before - tracing instance for: " + name + " " + message + " " + Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID"));
                // Call the broadcastMessage method to update clients.
                Clients.All.broadcastMessage(name, message);
                System.Diagnostics.Trace.WriteLine("after - tracing instance for: " + name + " " + message + " " + Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID"));
            }

            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("exception occurred during chathub on instance: " + Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID") + " " +ex.ToString());

            }
        }
    }
}