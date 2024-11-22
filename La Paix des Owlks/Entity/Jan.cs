using La_Paix_des_Owlks.Scene;
using nkast.Aether.Physics2D.Dynamics;
using SharpEngine.AetherPhysics;
using SharpEngine.Core;
using SharpEngine.Core.Component;
using SharpEngine.Core.Entity;
using SharpEngine.Core.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Entity
{
    internal class Jan: SharpEngine.Core.Entity.Entity
    {
        private ControlComponent _controlComponent;
        private SpriteComponent _spriteComponent;
        private TransformComponent _transformComponent;

        public Jan(Vec2 position)
        {
            Tag = "Jan";
            _transformComponent = AddComponent(new TransformComponent(position, scale: new Vec2(0.75f)));
            _spriteComponent = AddComponent(new SpriteComponent("Jan", true));
            AddComponent(new PhysicsComponent(BodyType.Dynamic, true, true, true))
                .AddRectangleCollision(new Vec2(70, 30), new Vec2(0, 35))
                .CollisionCallback += OnCollision;
            _controlComponent = AddComponent(new PhysicsControlComponent(speed: 200));
        }

        public override void Update(float delta)
        {
            base.Update(delta);

            _transformComponent.ZLayer = Convert.ToInt32(_transformComponent.Position.Y);

            if (_controlComponent.Direction.X > 0 && _spriteComponent.FlipX)
                _spriteComponent.FlipX = false;
            else if (_controlComponent.Direction.X < 0 && !_spriteComponent.FlipX)
                _spriteComponent.FlipX = true;
        }

        public void OnCollision(object? sender, PhysicsEventArgs args)
        {
            var system = Scene?.GetSceneSystem<PhysicsSystem>();
            if(system == null)
                return;

            SharpEngine.Core.Entity.Entity? senderEntity;
            Body? senderBody;
            if (system.GetEntityForBody(args.Other.Body) == this)
            {
                senderEntity = system.GetEntityForBody(args.Sender.Body);
                senderBody = args.Sender.Body;
            }
            else
            {
                senderEntity = system.GetEntityForBody(args.Other.Body);
                senderBody = args.Other.Body;
            }

            if (senderEntity == null)
                return;

            if (senderEntity?.Tag == "Rock" || senderEntity?.Tag == "Wood")
            {
                system.RemoveBody(senderBody, true);
                Scene!.RemoveEntity(senderEntity, true);

                switch(senderEntity.Tag)
                {
                    case "Rock":
                        LPDOConsts.Save.Stone += 1;
                        break;
                    case "Wood":
                        LPDOConsts.Save.Wood += 1;
                        break;
                }

                LPDOConsts.Save.Objects.RemoveAll( obj => 
                    obj.X == Convert.ToInt32(senderEntity.GetComponentAs<TransformComponent>()!.Position.X) && 
                    obj.Y == Convert.ToInt32(senderEntity.GetComponentAs<TransformComponent>()!.Position.Y) && 
                    obj.Type == senderEntity.Tag
                );
            }
        }
    }
}
