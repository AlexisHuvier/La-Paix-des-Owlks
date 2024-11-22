using La_Paix_des_Owlks.Entity;
using La_Paix_des_Owlks.Widget;
using Raylib_cs;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;

namespace La_Paix_des_Owlks.Scene
{
    internal class Game: SharpEngine.Core.Scene
    {
        public Jan Jan { get; private set; } = null!;

        public Game()
        {
            AddWidget(new Label(new Vec2(100, 20), "Bois : 0", "RAYLIB_DEFAULT", fontSize: 20));
            AddWidget(new Label(new Vec2(100, 50), "Pierre : 0", "RAYLIB_DEFAULT", fontSize: 20));
            AddWidget(new Label(new Vec2(100, 80), "Nourriture : 0", "RAYLIB_DEFAULT", fontSize: 20));
            AddWidget(new Label(new Vec2(100, 110), "Paix : 0", "RAYLIB_DEFAULT", fontSize: 20));

            AddWidget(new ActionBar());

            AddSceneSystem(new PhysicsSystem());
        }

        public override void OpenScene()
        {
            base.OpenScene();

            RemoveAllEntities();
            AddEntity(new Map()).Load();
            Jan = AddEntity(new Jan());
            Jan.Load();

            foreach(var object_ in LPDOConsts.Save.Objects)
            {
                var position = new Vec2(object_.X, object_.Y);
                SharpEngine.Core.Entity.Entity entity = object_.Type switch {
                    "Rock" => new Rock(position),
                    "Wood" => new Wood(position),
                    "House" => new House(position),
                    _ => throw new Exception("Unknown object type")
                };
                AddEntity(entity).Load();
            }

            Window!.CameraManager.FollowEntity = Jan;
            Window.CameraManager.FractionSpeed = 2.5f;
            Window.CameraManager.Mode = SharpEngine.Core.Utils.CameraMode.FollowSmooth;
        }

        public override void Unload()
        {
            base.Unload();

            LPDOConsts.Save.PlayerPosition = Jan.GetComponentAs<TransformComponent>()!.Position;
            LPDOConsts.Save.Save();
        }

        public override void Update(float delta)
        {
            base.Update(delta);

            var labels = GetWidgetsAs<Label>();
            labels[0].Text = $"Bois : {LPDOConsts.Save.Wood}";
            labels[1].Text = $"Pierre : {LPDOConsts.Save.Stone}";
            labels[2].Text = $"Nourriture : {LPDOConsts.Save.Food}";
            labels[3].Text = $"Paix : {LPDOConsts.Save.Peace}";

            var font = Window!.FontManager.GetFont("RAYLIB_DEFAULT");

            labels[0].Position = new Vec2(20 + Raylib.MeasureTextEx(font, labels[0].Text, 20, 2).X / 2, 20);
            labels[1].Position = new Vec2(20 + Raylib.MeasureTextEx(font, labels[1].Text, 20, 2).X / 2, 50);
            labels[2].Position = new Vec2(20 + Raylib.MeasureTextEx(font, labels[2].Text, 20, 2).X / 2, 80);
            labels[3].Position = new Vec2(20 + Raylib.MeasureTextEx(font, labels[3].Text, 20, 2).X / 2, 110);
        }

        public Vec2[] GetCameraCorners()
        {
            return [
                Window!.CameraManager.Position + new Vec2(-640, -460),
                Window!.CameraManager.Position + new Vec2(640, -460),
                Window!.CameraManager.Position + new Vec2(640, 460),
                Window!.CameraManager.Position + new Vec2(-640, 460)
            ];
        }
    }
}
