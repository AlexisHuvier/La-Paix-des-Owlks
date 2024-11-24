using SharpEngine.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Debug
{
    public static class DebugExtensions
    {
        public static void AddConsoleCommands()
        {
            DebugManager.AddConsoleCommand(new ModifyResourceConsoleCommand());
            DebugManager.AddConsoleCommand(new SpawnObjectConsoleCommand());
            DebugManager.AddConsoleCommand(new DespawnObjectConsoleCommand());
            DebugManager.AddConsoleCommand(new GetPositionObjectConsoleCommand());
        }
    }
}
