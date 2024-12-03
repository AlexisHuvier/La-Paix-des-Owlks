using nkast.Aether.Physics2D.Dynamics;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;

namespace La_Paix_des_Owlks.Entity
{
    internal class Statue: SharpEngine.Core.Entity.Entity
    {
        private TransformComponent _transformComponent;
        private PhysicsComponent _physicsComponent;

        public Statue(Vec2 position)
        {
            Tag = "Statue";
            _transformComponent = AddComponent(new TransformComponent(position, zLayer: 5));
            AddComponent(new SpriteComponent("Statue", true));
            _physicsComponent = AddComponent(new PhysicsComponent(BodyType.Static, true, true, true))
                .AddRectangleCollision(new Vec2(80, 30), new Vec2(0, 45));
        }        

        public override void Update(float delta)
        {
            base.Update(delta);
            _transformComponent.ZLayer = Convert.ToInt32(_transformComponent.Position.Y);
        }
    }
}
