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
        private Vec2 _barPos = new(LPDOConsts.HalfRenderSize.X, 75);

        class Image
        {
            public Texture2D? Texture;
            public Vec2 Pos;
            public Vec2 Size;
            public Vec2 FinalSize;
        }

        private Image[] _images = [
            new Image() { Texture = null, Pos = new Vec2(1000, 75), Size = new Vec2(100), FinalSize = new Vec2(100) },
            new Image() { Texture = null, Pos = new Vec2(275, 75), Size = new Vec2(100), FinalSize = new Vec2(100) },
            new Image() { Texture = null, Pos = new Vec2(350, 125), Size = new Vec2(100), FinalSize = new Vec2(48) },
            new Image() { Texture = null, Pos = new Vec2(500, 125), Size = new Vec2(100), FinalSize = new Vec2(48) },
            new Image() { Texture = null, Pos = new Vec2(650, 125), Size = new Vec2(100), FinalSize = new Vec2(48) },
            new Image() { Texture = null, Pos = new Vec2(800, 125), Size = new Vec2(100), FinalSize = new Vec2(48) }
        ];

        public TopHud() : base(Vec2.Zero, 1000)
        {
            AddChild(new Label(new Vec2(425, 125), "0", "RAYLIB_DEFAULT", fontSize: 30));
            AddChild(new Label(new Vec2(575, 125), "0", "RAYLIB_DEFAULT", fontSize: 30));
            AddChild(new Label(new Vec2(725, 125), "0", "RAYLIB_DEFAULT", fontSize: 30));
            AddChild(new Label(new Vec2(875, 125), "0", "RAYLIB_DEFAULT", fontSize: 30));
        }

        public override void Load()
        {
            base.Load();
            
            var nbImages = 0;

            foreach (var texture in new string[] { "Iris", "JanEmote" })
            {
                _images[nbImages].Texture = Scene!.Window!.TextureManager.GetTexture(texture);
                _images[nbImages].Size = new Vec2(_images[nbImages].Texture!.Value.Width, _images[nbImages].Texture!.Value.Height);
                _images[nbImages].FinalSize = _images[nbImages].Size;

                nbImages++;
            }

            foreach (var texture in new string[] { "Wood", "Rock", "Food", "Peace" })
            {
                _images[nbImages].Texture = Scene!.Window!.TextureManager.GetTexture(texture);
                _images[nbImages].Size = new Vec2(_images[nbImages].Texture!.Value.Width, _images[nbImages].Texture!.Value.Height);

                nbImages++;
            }
        }

        public override void Update(float delta)
        {
            base.Update(delta);

            var labels = GetChildrenAs<Label>();
            labels[0].Text = LPDOConsts.Save.Wood.ToString();
            labels[1].Text = LPDOConsts.Save.Stone.ToString();
            labels[2].Text = LPDOConsts.Save.Food.ToString();
            labels[3].Text = LPDOConsts.Save.Peace.ToString();
        }

        public override void Draw()
        {
            base.Draw();

            if(!Displayed)
                return;

            SERender.DrawRectangle(new Rect(_barPos, _barSize), _barSize / 2f, 0f, SharpEngine.Core.Utils.Color.Black, InstructionSource.UI, ZLayer);
            SERender.DrawRectangle(new Rect(_barPos, _barSize - 4f), (_barSize - 4f) / 2f, 0f, SharpEngine.Core.Utils.Color.Red, InstructionSource.UI, ZLayer + 0.0001f);
            SERender.DrawRectangle(new Rect(_barPos, (_barSize.X - 4f) * LPDOConsts.Save.ValueAgainstIris / 100f, _barSize.Y - 4f), (_barSize - 4f) / 2f, 0f, SharpEngine.Core.Utils.Color.Green, InstructionSource.UI, ZLayer + 0.0002f);
            foreach(var image in _images)
                SERender.DrawTexture(image.Texture!.Value, new Rect(Vec2.Zero, image.Size), new Rect(image.Pos, image.FinalSize), image.FinalSize / 2f, 0, SharpEngine.Core.Utils.Color.White, InstructionSource.UI, ZLayer + 0.0003f);

        }
    }
}
