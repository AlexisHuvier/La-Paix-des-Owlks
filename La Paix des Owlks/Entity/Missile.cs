using SharpEngine.Core.Component;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Entity
{
    internal class Missile: SharpEngine.Core.Entity.Entity
    {
        private TransformComponent transformComponent;
        private int speed = 400;

        public Missile(Vec2 position)
        {
            Tag = "Missile";
            transformComponent = AddComponent(new TransformComponent(position, zLayer: 500000));
            AddComponent(new SpriteComponent("Missile", true));
        }

        public override void Update(float delta)
        {
            base.Update(delta);

            var target = new Vec2(1000, 75) + (Scene!.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            var distance = target - transformComponent.Position;

            if (distance.LengthSquared() <= 4)
            {
                Scene!.RemoveEntity(this);
                LPDOConsts.Save.ValueAgainstIris += 1;
                return;
            }
            else
            {
                var parcours = distance.Normalized() * speed * delta;
                transformComponent.Position += parcours;
                transformComponent.Rotation = MathHelper.ToDegrees(MathF.Atan2(parcours.Y, parcours.X));
            }
        }
    }
}
