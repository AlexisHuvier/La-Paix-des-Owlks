using SharpEngine.Core.Math;
using SharpEngine.Core.Renderer;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Widget
{
    internal class ActionBarItem : Button
    {
        private string _texture;

        private Color _baseColor = new(255, 255, 255, 240);
        private Color _hoverColor = new(200, 200, 200, 240);

        public ActionBarItem(string texture, Vec2 position, int zLayer = 1050) : base(position, font: "RAYLIB_DEFAULT")
        {
            _texture = texture;
            Size = new Vec2(80, 80);
        }

        public override void Draw()
        {
            base.Draw();

            var texture = Scene!.Window!.TextureManager.GetTexture(_texture);
            var src = new Rect(0, 0, texture.Width, texture.Height);
            var dest = new Rect(Position.X, Position.Y, 80, 80);
            var origin = new Vec2(40, 40);
            if (_state == ButtonState.Hover)
                SERender.DrawTexture(texture, src, dest, origin, 0, _hoverColor, InstructionSource.UI, ZLayer);
            else
                SERender.DrawTexture(texture, src, dest, origin, 0, _baseColor, InstructionSource.UI, ZLayer);

        }
    }
}
