using nkast.Aether.Physics2D.Dynamics;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;

namespace La_Paix_des_Owlks.Entity
{
    internal class Lance: SharpEngine.Core.Entity.Entity
    {
        private TransformComponent _transformComponent;
        private PhysicsComponent _physicsComponent;
        private float _timer = 0;

        public Lance(Vec2 position)
        {
            Tag = "Lance";
            _transformComponent = AddComponent(new TransformComponent(position, zLayer: 5));
            AddComponent(new SpriteComponent("Lance", true));
            _physicsComponent = AddComponent(new PhysicsComponent(BodyType.Static, true, true, true))
                .AddRectangleCollision(new Vec2(100, 30), new Vec2(0, 35));
        }        

        public override void Update(float delta)
        {
            base.Update(delta);
            _transformComponent.ZLayer = Convert.ToInt32(_transformComponent.Position.Y);

            if (_timer >= 4)
            {
                _timer = 0;
            }
            _timer += delta;
        }
    }
}
