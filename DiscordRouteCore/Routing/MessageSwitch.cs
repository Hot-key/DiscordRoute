﻿using System;
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
            try
            {
                var userMessage = message as SocketUserMessage;
                SocketCommandContext context = new SocketCommandContext(Define.Option.client, userMessage);
                var cmd = message.Content.Split(' ');
                if (!context.User.IsBot)
                {
                    if (Msg.BufferDictionary.ContainsKey("MessageReceived"))
                    {
                        var action = Msg.BufferDictionary["MessageReceived"];

                        action(message, message.Content);
                    }
                    if (Msg.BufferDictionary.ContainsKey(cmd[0]))
                    {
                        var action = Msg.BufferDictionary[cmd[0]];

                        action(message, message.Content);
                    }
                    await Log(new LogMessage(LogSeverity.Info, "Command", $"{context.User} : {context.Message}"));
                }
            }
            catch (Exception e)
            {
                await Log(new LogMessage(LogSeverity.Info, "Exception!", $"{e.Message}"));
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}