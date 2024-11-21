using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Entity
{
    internal class Wood : SharpEngine.Core.Entity.Entity
    {       
        public Wood(Vec2 position)
        {
            Tag = "Wood";
            AddComponent(new TransformComponent(position, zLayer: 9));
            AddComponent(new SpriteComponent("Wood", true));
            AddComponent(new PhysicsComponent(nkast.Aether.Physics2D.Dynamics.BodyType.Static, true, true, true))
                .AddRectangleCollision(new Vec2(40, 70), Vec2.Zero);
        }
    }
}
