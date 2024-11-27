using La_Paix_des_Owlks.Entity;
using La_Paix_des_Owlks.System;
using La_Paix_des_Owlks.Widget;
using Raylib_cs;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;

namespace La_Paix_des_Owlks.Scene
{
    internal class Game: SharpEngine.Core.Scene
    {
        public Jan Jan { get; private set; } = null!;
        public float IrisPointTime = 1;
        public float IrisPoint = 1;

        private float _time = 0;

        public Game()
        {
            AddWidget(new TopHud());
            AddWidget(new ActionBar());

            AddSceneSystem(new PhysicsSystem());
            AddSceneSystem(new ActionSystem(this));


            AddEntity(new Map());
            Jan = AddEntity(new Jan(LPDOConsts.Save.PlayerPosition));

            foreach (var object_ in LPDOConsts.Save.Objects)
            {
                var position = new Vec2(object_.X, object_.Y);
                SharpEngine.Core.Entity.Entity entity = object_.Type switch
                {
                    "Rock" => new Rock(position),
                    "Wood" => new Wood(position),
                    "House" => new House(position),
                    _ => throw new Exception("Unknown object type")
                };
                AddEntity(entity);
            }
        }

        public override void Load()
        {
            base.Load();

            Window!.CameraManager.FollowEntity = Jan;
            Window.CameraManager.FractionSpeed = 2.5f;
            Window.CameraManager.Mode = SharpEngine.Core.Utils.CameraMode.FollowSmooth;
        }

        public override void Update(float delta)
        {
            base.Update(delta);

            _time += delta;
            if (_time >= IrisPointTime)
            {
                _time = 0;
                LPDOConsts.Save.ValueAgainstIris -= IrisPoint;
                if(LPDOConsts.Save.ValueAgainstIris <= 0)
                {
                    DebugManager.Log(SharpEngine.Core.Utils.LogLevel.LogInfo, "GAME: Game Over");
                }
            }

        }

        public override void Unload()
        {
            base.Unload();

            LPDOConsts.Save.PlayerPosition = Jan.GetComponentAs<TransformComponent>()!.Position;
            LPDOConsts.Save.Save();
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
