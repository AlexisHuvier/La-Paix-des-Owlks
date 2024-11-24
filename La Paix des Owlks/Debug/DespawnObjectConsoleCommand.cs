using La_Paix_des_Owlks.Scene;
using SharpEngine.AetherPhysics;
using SharpEngine.Core;
using SharpEngine.Core.Component;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils.SeImGui;
using SharpEngine.Core.Utils.SeImGui.ConsoleCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace La_Paix_des_Owlks.Debug
{
    internal class DespawnObjectConsoleCommand : ISeImGuiConsoleCommand
    {
        public string Command => "despawnObject";

        public void Process(string[] args, SeImGuiConsole console, Window window)
        {
            if (args.Length != 3)
            {
                console.AddText("Usage: despawnObject <object> <x> <y>");
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

            if (window.CurrentScene is not Game gameScene)
            {
                console.AddText("Invalid scene");
                return;
            }

            var position = new Vec2(x, y);
            foreach (var entity in gameScene.Entities)
            {
                if (entity.Tag == args[0] && entity.GetComponentAs<TransformComponent>() is { } transform && entity.GetComponentAs<SpriteComponent>() is { } sprite)
                {
                    var texture = gameScene.Window!.TextureManager.GetTexture(sprite.Texture);
                    var width = texture.Width * transform.Scale.X;
                    var height = texture.Height * transform.Scale.Y;
                    var otherRect = new Rect(transform.Position.X - width / 2, transform.Position.Y - height / 2, width, height);
                    if (otherRect.Contains(position))
                    {
                        LPDOConsts.Save.Objects.RemoveAll(obj =>
                            obj.X == Convert.ToInt32(transform.Position.X) &&
                            obj.Y == Convert.ToInt32(transform.Position.Y) &&
                            obj.Type == entity.Tag
                        );

                        if (entity.GetComponentAs<PhysicsComponent>() is { } physics && physics.Body != null)
                            gameScene.GetSceneSystem<PhysicsSystem>()!.RemoveBody(physics.Body, true);
                        gameScene.RemoveEntity(entity, true);

                        console.AddText($"Despawned {args[0]} at {x}, {y}");
                    }
                }
            }
        }
    }
}
