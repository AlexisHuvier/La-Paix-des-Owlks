using La_Paix_des_Owlks.Entity;
using La_Paix_des_Owlks.Scene;
using SharpEngine.Core;
using SharpEngine.Core.Utils.SeImGui;
using SharpEngine.Core.Utils.SeImGui.ConsoleCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Debug
{
    internal class SpawnObjectConsoleCommand : ISeImGuiConsoleCommand
    {
        public string Command => "spawnObject";

        public void Process(string[] args, SeImGuiConsole console, Window window)
        {
            if (args.Length != 3)
            {
                console.AddText("Usage: spawnObject <object> <x> <y>");
                return;
            }

            if (!int.TryParse(args[1], out int x))
            {
                console.AddText("Invalid x");
                return;
            }

            if (!int.TryParse(args[2], out int y))
            {
                console.AddText("Invalid y");
                return;
            }

            if(window.CurrentScene is not Game gameScene)
            {
                console.AddText("Invalid scene");
                return;
            }

            SharpEngine.Core.Entity.Entity entity;
            switch (args[0])
            {
                case "house":
                    entity = new House(new SharpEngine.Core.Math.Vec2(x, y));
                    LPDOConsts.Save.Objects.Add(new Object { Type = "House", X = x, Y = y });
                    break;
                case "wood":
                    entity = new Wood(new SharpEngine.Core.Math.Vec2(x, y));
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Wood", X = x, Y = y });
                    break;
                case "rock":
                    entity = new Rock(new SharpEngine.Core.Math.Vec2(x, y));
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Rock", X = x, Y = y });
                    break;
                case "farm":
                    entity = new Farm(new SharpEngine.Core.Math.Vec2(x, y));
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Farm", X = x, Y = y });
                    break;
                case "sawmill":
                    entity = new Sawmill(new SharpEngine.Core.Math.Vec2(x, y));
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Sawmill", X = x, Y = y });
                    break;
                case "mine":
                    entity = new Mine(new SharpEngine.Core.Math.Vec2(x, y));
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Mine", X = x, Y = y });
                    break;
                case "statue":
                    entity = new Statue(new SharpEngine.Core.Math.Vec2(x, y));
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Statue", X = x, Y = y });
                    break;
                default:
                    console.AddText("Invalid object");
                    return;
            }

            gameScene.AddEntity(entity).Load();
            console.AddText($"Spawned {args[0]} at {x}, {y}");
        }
    }
}
