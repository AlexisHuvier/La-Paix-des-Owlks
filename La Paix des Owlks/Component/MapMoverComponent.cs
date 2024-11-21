using La_Paix_des_Owlks.Entity;
using La_Paix_des_Owlks.Scene;
using SharpEngine.Core.Component;
using SharpEngine.Core.Math;

namespace La_Paix_des_Owlks.Component
{
    internal class MapMoverComponent: SharpEngine.Core.Component.Component
    {
        private TransformComponent? _transformComponent;

        public override void Load()
        {
            base.Load();

            _transformComponent = Entity?.GetComponentAs<TransformComponent>();
        }

        public override void Update(float delta)
        {
            base.Update(delta);

            if (Entity == null || _transformComponent == null)
                return;

            var corners = ((Map)Entity).GetCorners();
            var cameraCorners = Entity.GetSceneAs<Game>()!.GetCameraCorners();
            var position = _transformComponent.Position;

            if (cameraCorners[0].X <= corners[0].X && cameraCorners[0].Y <= corners[0].Y)
                _transformComponent.Position = corners[0];
            else if (cameraCorners[1].X >= corners[1].X && cameraCorners[1].Y <= corners[1].Y)
                _transformComponent.Position = corners[1];
            else if (cameraCorners[2].X >= corners[2].X && cameraCorners[2].Y >= corners[2].Y)
                _transformComponent.Position = corners[2];
            else if (cameraCorners[3].X <= corners[0].X && cameraCorners[3].Y >= corners[3].Y)
                _transformComponent.Position = corners[3];
            else if (cameraCorners[0].Y <= corners[0].Y)
                _transformComponent.Position = new Vec2(_transformComponent.Position.X, corners[0].Y);
            else if (cameraCorners[1].X >= corners[1].X)
                _transformComponent.Position = new Vec2(corners[1].X, _transformComponent.Position.Y);
            else if (cameraCorners[2].Y >= corners[2].Y)
                _transformComponent.Position = new Vec2(_transformComponent.Position.X, corners[2].Y);
            else if (cameraCorners[3].X <= corners[3].X)
                _transformComponent.Position = new Vec2(corners[3].X, _transformComponent.Position.Y);

            if (position != _transformComponent.Position)
                ((Map)Entity).CalculateCorners();
        }
    }
}
