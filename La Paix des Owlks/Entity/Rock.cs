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
    internal class Rock : SharpEngine.Core.Entity.Entity
    {       
        public Rock(Vec2 position)
        {
            Tag = "Rock";
            AddComponent(new TransformComponent(position, new Vec2(2), zLayer: 9));
            AddComponent(new SpriteComponent("Rock", true));
            AddComponent(new PhysicsComponent(nkast.Aether.Physics2D.Dynamics.BodyType.Static, true, true, true))
                .AddRectangleCollision(new Vec2(40, 35), new Vec2(0, 5));
        }
    }
}
