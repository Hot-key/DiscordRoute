using System;

namespace DiscordRouteCore.Routing
{
    public class FunctionScan
    {
        public static void StartScan()
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in asm.GetTypes())
                {
                    if (type.BaseType != null)
                    {
                        if (type.BaseType.Name == "Function")
                        {
                            dynamic instance = Activator.CreateInstance(type);
                        }
                    }
                }
            }
        }
    }
}
