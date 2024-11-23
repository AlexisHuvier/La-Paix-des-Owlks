using SharpEngine.Core.Component;
using SharpEngine.Core.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Entity
{
    internal class Eraser: SharpEngine.Core.Entity.Entity
    {
        public Eraser()
        {
            Tag = "Eraser";

            AddComponent(new TransformComponent(Vec2.Zero, scale: new Vec2(0.5f), zLayer: int.MaxValue));
            AddComponent(new SpriteComponent("Eraser", offset: new Vec2(20, 20)));
        }
    }
}
