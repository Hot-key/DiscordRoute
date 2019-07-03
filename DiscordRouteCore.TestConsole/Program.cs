using System;
using DiscordRouteCore.Routing;

namespace DiscordRouteCore.TestConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Router.Start("NTgyNzc2MTA0MzAxODg3NDk5.XOyvCA.FUVfa5SsbHO8JmYDZ_x0GM1f1ZQ").GetAwaiter().GetResult(); ;
        }
    }

    public class Test : Routing.Function
    {
        public Test()
        {
            msg["--Test"] = async (message, list) =>
            {
                Console.WriteLine("Test");
                await message.Channel.SendMessageAsync("DiscordRouteTest");
            };
        }
    }
}
