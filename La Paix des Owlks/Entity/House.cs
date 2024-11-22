using nkast.Aether.Physics2D.Dynamics;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;

namespace La_Paix_des_Owlks.Entity
{
    internal class House: SharpEngine.Core.Entity.Entity
    {
        private TransformComponent _transformComponent;
        private PhysicsComponent _physicsComponent;

        public House(Vec2 position)
        {
            Tag = "House";
            _transformComponent = AddComponent(new TransformComponent(position, zLayer: 5, scale: new Vec2(1.5f)));
            AddComponent(new SpriteComponent("House", true));
            _physicsComponent = AddComponent(new PhysicsComponent(BodyType.Static, true, true, true))
                .AddRectangleCollision(new Vec2(210, 230), new Vec2(-20, 35));
        }        

        public override void Update(float delta)
        {
            base.Update(delta);
            _transformComponent.ZLayer = Convert.ToInt32(_transformComponent.Position.Y);
        }
    }
}
