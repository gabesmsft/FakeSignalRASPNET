using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
//using Microsoft.AspNet.SignalR.StackExchangeRedis;
using Microsoft.AspNet.SignalR.Redis;
using Microsoft.AspNet.SignalR;

//https://docs.microsoft.com/en-us/aspnet/signalr/overview/performance/scaleout-with-redis

//https://stackoverflow.com/questions/35325531/signalr-redis-backplane-not-working-dependency-issue


[assembly: OwinStartup(typeof(FakeSignalRAspNet.Startup))]

//https://github.com/aspnet/AzureSignalR-samples/tree/master/aspnet-samples/ChatRoom

namespace FakeSignalRAspNet
{
    public class Startup
    {
        private string connectionString = "MyFakeRedisNamespace.redis.cache.windows.net:6380,password=MyFakeRedispassword=,ssl=True,abortConnect=False";
        private string eventKey = "FakeSignalRAspNet";

        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            try
            {
                GlobalHost.DependencyResolver.UseRedis(new RedisScaleoutConfiguration(connectionString, eventKey));
                app.MapSignalR();
                System.Diagnostics.Trace.WriteLine("connected to redis");

            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("exception occurred: " + ex.ToString());
            }
        }
    }
}
