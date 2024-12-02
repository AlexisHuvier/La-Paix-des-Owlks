using SharpEngine.Core.Component;
using SharpEngine.Core.Manager;
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
        private readonly string[] CanBeErasedTags = ["House", "Farm", "Sawmill", "Mine"];

        public Eraser()
        {
            Tag = "Eraser";

            AddComponent(new TransformComponent(Vec2.Zero, scale: new Vec2(0.5f), zLayer: int.MaxValue));
            AddComponent(new SpriteComponent("Eraser", offset: new Vec2(20, 20)));
        }

        public SharpEngine.Core.Entity.Entity? GetErasedEntity()
        {
            var position = InputManager.GetMousePosition() + (Scene!.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);

            foreach (var entity in Scene!.Entities)
            {
                if (CanBeErasedTags.Contains(entity.Tag) && entity.GetComponentAs<TransformComponent>() is { } transform && entity.GetComponentAs<SpriteComponent>() is { } sprite)
                {
                    var texture = Scene.Window!.TextureManager.GetTexture(sprite.Texture);
                    var width = texture.Width * transform.Scale.X;
                    var height = texture.Height * transform.Scale.Y;
                    var otherRect = new Rect(transform.Position.X - width / 2, transform.Position.Y - height / 2, width, height);
                    if (otherRect.Contains(position))
                        return entity;
                }
            }

            return null;
        }
    }
}
