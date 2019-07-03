using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DiscordRouteCore.Config;

namespace DiscordRouteCore.Routing
{
    public static class Router
    {
        public static async Task Start(string token)
        {
            FunctionScan.StartScan();

            Define.Option = new Option()
            {
                client = new DiscordSocketClient(),
                msg = new MessageSwitch(),
            };

            Define.Option.client = new DiscordSocketClient();
            Define.Option.msg = new MessageSwitch();
            Define.Option.client.Log += Define.Option.Log;
            await Define.Option.client.LoginAsync(TokenType.Bot, token);
            await Define.Option.client.StartAsync();
            Define.Option.client.MessageReceived += Define.Option.msg.MessageReceived;
            Define.Option.client.Ready += Define.Option.ClientReady;
            Define.Option.client.GuildAvailable += Define.Option.ClientGuildAvailable;
            await Task.Delay(-1); // 프로그램 종료시까지 태스크 유지  
        }
    }

    public static class Router<T> where T : OptionBase
    {
        public static async Task Start(T option, string token)
        {
            FunctionScan.StartScan();

            Define.Option = option;

            Define.Option.client = new DiscordSocketClient();
            Define.Option.msg = new MessageSwitch();
            Define.Option.client.Log += Define.Option.Log;
            await Define.Option.client.LoginAsync(TokenType.Bot, token);
            await Define.Option.client.StartAsync();
            Define.Option.client.MessageReceived += Define.Option.msg.MessageReceived;
            Define.Option.client.Ready += Define.Option.ClientReady;
            Define.Option.client.GuildAvailable += Define.Option.ClientGuildAvailable;
            await Task.Delay(-1); // 프로그램 종료시까지 태스크 유지  
        }
    }
}
