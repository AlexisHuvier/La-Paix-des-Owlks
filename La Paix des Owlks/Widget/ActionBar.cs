using SharpEngine.Core.Math;
using SharpEngine.Core.Renderer;
using SharpEngine.Core.Utils;

namespace La_Paix_des_Owlks.Widget
{
    internal class ActionBar(int zLayer = 1000) : SharpEngine.Core.Widget.Widget(Vec2.Zero, zLayer)
    {
        public override void Draw()
        {
            base.Draw();

            if(Scene == null)
                return;

            SERender.DrawRectangle(240, 750, 800, 100, new Color(200, 200, 200, 100), InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(245, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(345, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(445, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(545, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(645, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(745, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(845, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(945, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);

        }

    }
}
