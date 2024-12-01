using nkast.Aether.Physics2D.Dynamics;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;

namespace La_Paix_des_Owlks.Entity
{
    internal class Farm: SharpEngine.Core.Entity.Entity
    {
        private TransformComponent _transformComponent;
        private PhysicsComponent _physicsComponent;
        private float _timer = 0;

        public Farm(Vec2 position)
        {
            Tag = "Farm";
            _transformComponent = AddComponent(new TransformComponent(position, zLayer: 5, scale: new Vec2(1.5f)));
            AddComponent(new SpriteComponent("Farm", true));
            _physicsComponent = AddComponent(new PhysicsComponent(BodyType.Static, true, true, true))
                .AddRectangleCollision(new Vec2(300, 200), new Vec2(0, 35));
        }        

        public override void Update(float delta)
        {
            base.Update(delta);
            _transformComponent.ZLayer = Convert.ToInt32(_transformComponent.Position.Y);
            _timer += delta;

            if(_timer >= 2)
            {
                _timer = 0;
                LPDOConsts.Save.Food += 1;
            }

        }
    }
}
