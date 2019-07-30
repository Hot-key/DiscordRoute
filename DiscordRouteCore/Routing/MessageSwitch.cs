using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordRouteCore.Config;

namespace DiscordRouteCore.Routing
{
    public class MessageSwitch
    {
        public async Task MessageReceived(SocketMessage message)
        {
            new Task(async()  => 
            {
                try
                {
                    var userMessage = message as SocketUserMessage;
                    SocketCommandContext context = new SocketCommandContext(Define.Option.client, userMessage);
                    var cmd = message.Content.Split(' ');
                    if (!context.User.IsBot)
                    {
                        if (Msg.BufferDictionary.ContainsKey("BeforeMessage"))
                        {
                            var action = Msg.BufferDictionary["BeforeMessage"];

                            await action(message, message.Content);
                        }
                        if (Msg.BufferDictionary.ContainsKey(cmd[0]))
                        {
                            var action = Msg.BufferDictionary[cmd[0]];

                            await action(message, message.Content);
                        }
                        else if (Msg.BufferDictionary.ContainsKey("ErrorMessage"))
                        {
                            var action = Msg.BufferDictionary["ErrorMessage"];

                            await action(message, message.Content);
                        }
                        if (Msg.BufferDictionary.ContainsKey("AfterMessage"))
                        {
                            var action = Msg.BufferDictionary["AfterMessage"];

                            await action(message, message.Content);
                        }
                        await Log(new LogMessage(LogSeverity.Info, "Command", $"{context.User} : {context.Message}"));
                    }
                }
                catch (Exception e)
                {
                    await Log(new LogMessage(LogSeverity.Info, "Exception!", $"{e.Message}"));
                }
            }).Start();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}