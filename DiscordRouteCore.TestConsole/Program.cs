using System;
using DiscordRouteCore.Config;
using DiscordRouteCore.Routing;

namespace DiscordRouteCore.TestConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Router.Start("Discord bot token").GetAwaiter().GetResult(); ;
        }
    }

    public class Test : Routing.Function
    {
        public Test()
        {
            // All Message
            msg["BeforeMessage"] = async (message, list) =>
            {
                Console.WriteLine("Test");
                await message.Channel.SendMessageAsync("DiscordRouteTest - MessageReceived");
            };

            // --Test 
            msg["--Test"] = async (message, list) =>
            {
                Console.WriteLine("Test");
                await message.Channel.SendMessageAsync("DiscordRouteTest - --Test");
            };

        }
    }
}
