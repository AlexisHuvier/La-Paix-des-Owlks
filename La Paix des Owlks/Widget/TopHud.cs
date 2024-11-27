using Raylib_cs;
using SharpEngine.Core;
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
    internal class TopHud : SharpEngine.Core.Widget.Widget
    {
        private Vec2 _barSize = new(600, 50);
        private Vec2 _barPos = new(LPDOConsts.HalfRenderSize.X, 100);
        private Texture2D _irisTexture;
        private Vec2 _irisPos = new(1000, 100);
        private Vec2 _irisSize = new(100);
        private Texture2D _janTexture;
        private Vec2 _janPos = new(275, 100);
        private Vec2 _janSize = new(100);

        public TopHud() : base(Vec2.Zero, 1000)
        {}

        public override void Load()
        {
            base.Load();
            _irisTexture = Scene!.Window!.TextureManager.GetTexture("Iris");
            _irisSize = new Vec2(_irisTexture.Width, _irisTexture.Height);
            _janTexture = Scene!.Window!.TextureManager.GetTexture("JanEmote");
            _janSize = new Vec2(_janTexture.Width, _janTexture.Height);
        }

        public override void Draw()
        {
            base.Draw();

            if(!Displayed)
                return;

            SERender.DrawRectangle(new Rect(_barPos, _barSize), _barSize / 2f, 0f, SharpEngine.Core.Utils.Color.Black, InstructionSource.UI, ZLayer);
            SERender.DrawRectangle(new Rect(_barPos, _barSize - 4f), (_barSize - 4f) / 2f, 0f, SharpEngine.Core.Utils.Color.Red, InstructionSource.UI, ZLayer + 0.0001f);
            SERender.DrawRectangle(new Rect(_barPos, (_barSize.X - 4f) * LPDOConsts.Save.ValueAgainstIris / 100f, _barSize.Y - 4f), (_barSize - 4f) / 2f, 0f, SharpEngine.Core.Utils.Color.Green, InstructionSource.UI, ZLayer + 0.0002f);
            SERender.DrawTexture(_janTexture, new Rect(Vec2.Zero, _janSize), new Rect(_janPos, _janSize), _janSize / 2f, 0, SharpEngine.Core.Utils.Color.White, InstructionSource.UI, ZLayer + 0.0003f);
            SERender.DrawTexture(_irisTexture, new Rect(Vec2.Zero, _irisSize), new Rect(_irisPos, _irisSize), _irisSize / 2f, 0, SharpEngine.Core.Utils.Color.White, InstructionSource.UI, ZLayer + 0.0003f);
        }
    }
}
