using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordRouteCore.Routing;

namespace DiscordRouteCore.Config
{
    public class Option : OptionBase
    {
        public override Task ClientGuildAvailable(SocketGuild arg)
        {
            return Task.CompletedTask;
        }

        public override Task ClientReady()
        {
            return Task.CompletedTask;
        }
    }

    public abstract class OptionBase
    {
        public MessageSwitch msg;
        public DiscordSocketClient client;

        public abstract Task ClientGuildAvailable(SocketGuild arg);

        public abstract Task ClientReady();

        public Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
