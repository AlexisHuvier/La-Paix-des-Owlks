using La_Paix_des_Owlks.Component;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;

namespace La_Paix_des_Owlks.Entity
{
    internal class Map: SharpEngine.Core.Entity.Entity
    {
        private static readonly Vec2 SpriteOffset = new(640, 460);
        private readonly Vec2[] _corners = [Vec2.Zero, Vec2.Zero, Vec2.Zero, Vec2.Zero];
        private readonly TransformComponent _transformComponent;

        public Map()
        {
            _transformComponent = new TransformComponent(Vec2.Zero, Vec2.One, 0, zLayer: int.MinValue);
            AddComponent(new SpriteComponent("bg", true, SpriteOffset));
            AddComponent(new SpriteComponent("bg", true, -SpriteOffset));
            AddComponent(new SpriteComponent("bg", true, new Vec2(SpriteOffset.X, -SpriteOffset.Y)));
            AddComponent(new SpriteComponent("bg", true, new Vec2(-SpriteOffset.X, SpriteOffset.Y)));
            AddComponent(new MapMoverComponent());
            AddComponent(_transformComponent);
            CalculateCorners();
        }

        public void CalculateCorners()
        {
            var position = _transformComponent.Position;

            _corners[0] = new Vec2(position.X - SpriteOffset.X * 2, position.Y - SpriteOffset.Y * 2);
            _corners[1] = new Vec2(position.X + SpriteOffset.X * 2, position.Y - SpriteOffset.Y * 2);
            _corners[2] = new Vec2(position.X + SpriteOffset.X * 2, position.Y + SpriteOffset.Y * 2);
            _corners[3] = new Vec2(position.X - SpriteOffset.X * 2, position.Y + SpriteOffset.Y * 2);
        }

        public Vec2[] GetCorners() => _corners;

    }
}
