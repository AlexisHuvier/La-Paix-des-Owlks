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
        public SharpEngine.Core.Entity.Entity? Resource0 { get; private set; } = null;
        public SharpEngine.Core.Entity.Entity? Resource1 { get; private set; } = null;
        public SharpEngine.Core.Entity.Entity? Resource2 { get; private set; } = null;
        public SharpEngine.Core.Entity.Entity? Resource3 { get; private set; } = null;

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

            if (!LPDOConsts.Save.Taken0) {
                Resource0 = AddEntity(new Rock(new Vec2(300, 300)));
                Resource0.Load();
            }
            if (!LPDOConsts.Save.Taken1)
            {
                Resource1 = AddEntity(new Rock(new Vec2(900, 600)));
                Resource1.Load();
            }
            if (!LPDOConsts.Save.Taken2)
            {
                Resource2 = AddEntity(new Wood(new Vec2(300, 600)));
                Resource2.Load();
            }
            if (!LPDOConsts.Save.Taken3)
            {
                Resource3 = AddEntity(new Wood(new Vec2(900, 300)));
                Resource3.Load();
            }

            Window!.CameraManager.FollowEntity = Jan;
            Window.CameraManager.FractionSpeed = 2.5f;
            Window.CameraManager.Mode = SharpEngine.Core.Utils.CameraMode.FollowSmooth;
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
