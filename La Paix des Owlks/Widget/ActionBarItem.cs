using SharpEngine.Core.Manager;
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

        private Color _baseColor = new(255, 255, 255, 200);
        private Color _hoverColor = new(200, 200, 200, 200);
        private readonly string _tooltip;
        private readonly Vec2 _tooltipSize;

        public ActionBarItem(string texture, Vec2 position, string tooltip, Vec2 tooltipSize, int zLayer = 1050) : base(position, font: "RAYLIB_DEFAULT", zLayer: zLayer)
        {
            _texture = texture;
            Size = new Vec2(80);
            _tooltip = tooltip;
            _tooltipSize = tooltipSize;
        }

        public override void Draw()
        {
            base.Draw();

            var texture = Scene!.Window!.TextureManager.GetTexture(_texture);
            var src = new Rect(0, 0, texture.Width, texture.Height);
            var dest = new Rect(Position.X, Position.Y, 80, 80);
            var origin = new Vec2(40, 40);

            switch(_state)
            {
                case ButtonState.Down:
                    DrawBaseTexture(texture, src, dest, origin);
                    DrawTooltip();
                    break;
                case ButtonState.Hover:
                    DrawHoverTexture(texture, src, dest, origin);
                    DrawTooltip();
                    break;
                case ButtonState.Idle:
                    DrawBaseTexture(texture, src, dest, origin);
                    break;
            }
        }

        private void DrawTooltip()
        {
            var position = InputManager.GetMousePosition();
            SERender.DrawRectangle(new Rect(position.X, position.Y, _tooltipSize.X, _tooltipSize.Y), Vec2.Zero, 0, Color.White, InstructionSource.UI, ZLayer + 1);
            SERender.DrawRectangle(new Rect(position.X + 2, position.Y + 2, _tooltipSize.X - 4, _tooltipSize.Y - 4), Vec2.Zero, 0, _hoverColor, InstructionSource.UI, ZLayer + 2);
            var font = Scene!.Window!.FontManager.GetFont("RAYLIB_DEFAULT");
            SERender.DrawText(font, _tooltip, new Vec2(position.X + 5, position.Y + 5), Vec2.Zero, 0, 20, 2, Color.Black, InstructionSource.UI, ZLayer + 3);
        }

        private void DrawBaseTexture(Raylib_cs.Texture2D texture, Rect src, Rect dest, Vec2 origin) => 
            SERender.DrawTexture(texture, src, dest, origin, 0, _baseColor, InstructionSource.UI, ZLayer);
        private void DrawHoverTexture(Raylib_cs.Texture2D texture, Rect src, Rect dest, Vec2 origin) =>
            SERender.DrawTexture(texture, src, dest, origin, 0, _hoverColor, InstructionSource.UI, ZLayer);
    }
}
