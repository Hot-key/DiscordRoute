using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace DiscordRouteCore.Routing
{
    public class Msg
    {
        public Func<SocketMessage, string, Task> this[dynamic i]
        {
            set
            {
                Console.WriteLine(i);
                this.Add(i, value);
            }
        }

        public static Dictionary<dynamic, Func<SocketMessage, string, Task>> BufferDictionary = new Dictionary<dynamic, Func<SocketMessage, string, Task>>();

        public void Add(dynamic type, Func<SocketMessage , string, Task> action)
        {
            BufferDictionary.Add(type, action);
        }
    }
}
