using nkast.Aether.Physics2D.Collision;
using nkast.Aether.Physics2D.Dynamics;
using nkast.Aether.Physics2D.Dynamics.Contacts;
using SharpEngine.AetherPhysics;
using SharpEngine.Core.Component;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Renderer;
using SharpEngine.Core.Utils;

namespace La_Paix_des_Owlks.Entity
{
    internal class GhostTemple : SharpEngine.Core.Entity.Entity
    {
        public TransformComponent TransformComponent { get; set; }
        public bool Displayed { get; set; } = false;

        private Color whiteTransparent = new(255, 255, 255, 128);
        private Color redTransparent = new(255, 0, 0, 128);
        private readonly string[] CantBuildTags = ["Temple", "Statue", "Mine", "Sawmill", "Farm", "House", "Rock", "Wood", "Jan"];

        public GhostTemple(Vec2 position)
        {
            Tag = "Ghost";
            TransformComponent = AddComponent(new TransformComponent(position, zLayer: int.MaxValue, scale: new Vec2(1.5f)));
        }

        public override void Draw()
        {
            base.Draw();

            if (!Displayed)
                return;

            var position = TransformComponent.Position;
            var finalTexture = Scene!.Window!.TextureManager.GetTexture("Temple");
            SERender.DrawTexture(
                finalTexture,
                new Rect(0f, 0f, finalTexture.Width, finalTexture.Height),
                new Rect(position.X, position.Y, finalTexture.Width * TransformComponent.Scale.X, finalTexture.Height * TransformComponent.Scale.Y),
                new Vec2(finalTexture.Width / 2f * TransformComponent.Scale.X, finalTexture.Height / 2f * TransformComponent.Scale.Y),
                TransformComponent.Rotation,
                CanBuild() ? whiteTransparent : redTransparent,
                InstructionSource.Entity,
                TransformComponent.ZLayer
            );
        }

        public bool CanBuild()
        {
            var finalTexture = Scene!.Window!.TextureManager.GetTexture("Temple");
            var rect = new Rect(
                TransformComponent.Position.X - finalTexture.Width / 2 * TransformComponent.Scale.X, 
                TransformComponent.Position.Y - finalTexture.Height / 2 * TransformComponent.Scale.Y,
                finalTexture.Width * TransformComponent.Scale.X,
                finalTexture.Height * TransformComponent.Scale.Y
            );

            foreach(var entity in Scene!.Entities)
            {
                if(CantBuildTags.Contains(entity.Tag) && entity.GetComponentAs<TransformComponent>() is { } transform && entity.GetComponentAs<SpriteComponent>() is { } sprite)
                {
                    var texture = Scene.Window!.TextureManager.GetTexture(sprite.Texture);
                    var width = texture.Width * transform.Scale.X;
                    var height = texture.Height * transform.Scale.Y;
                    var otherRect = new Rect(transform.Position.X - width / 2, transform.Position.Y - height / 2, width, height);
                    if(rect.Intersect(otherRect))
                        return false;
                }
            }

            return true;
        }
    }
}
