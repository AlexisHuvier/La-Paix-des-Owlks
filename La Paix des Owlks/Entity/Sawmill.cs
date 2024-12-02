using nkast.Aether.Physics2D.Dynamics;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;

namespace La_Paix_des_Owlks.Entity
{
    internal class Sawmill: SharpEngine.Core.Entity.Entity
    {
        private TransformComponent _transformComponent;
        private PhysicsComponent _physicsComponent;
        private float _timer = 0;

        public Sawmill(Vec2 position)
        {
            Tag = "Sawmill";
            _transformComponent = AddComponent(new TransformComponent(position, zLayer: 5));
            AddComponent(new SpriteComponent("Sawmill", true));
            _physicsComponent = AddComponent(new PhysicsComponent(BodyType.Static, true, true, true))
                .AddRectangleCollision(new Vec2(200, 100), Vec2.Zero);
        }        

        public override void Update(float delta)
        {
            base.Update(delta);
            _transformComponent.ZLayer = Convert.ToInt32(_transformComponent.Position.Y);
            _timer += delta;

            if(_timer >= 4)
            {
                _timer = 0;
                LPDOConsts.Save.Wood += 1;
            }

        }
    }
}
