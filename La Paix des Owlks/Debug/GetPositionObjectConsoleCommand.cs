using La_Paix_des_Owlks.Scene;
using SharpEngine.Core;
using SharpEngine.Core.Component;
using SharpEngine.Core.Utils.SeImGui;
using SharpEngine.Core.Utils.SeImGui.ConsoleCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Debug
{
    internal class GetPositionObjectConsoleCommand : ISeImGuiConsoleCommand
    {
        public string Command => "getPosition";

        public void Process(string[] args, SeImGuiConsole console, Window window)
        {
            if (args.Length != 1)
            {
                console.AddText("Usage: getPosition <object>");
                return;
            }

            if (window.CurrentScene is not Game gameScene)
            {
                console.AddText("Invalid scene");
                return;
            }

            foreach (var entity in gameScene.Entities)
            {
                if (entity.Tag == args[0] && entity.GetComponentAs<TransformComponent>() is { } transform)
                    console.AddText($"Position: {transform.Position}");
            }
        }
    }
}
