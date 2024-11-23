using La_Paix_des_Owlks.System;
using La_Paix_des_Owlks.Utils;
using SharpEngine.Core.Math;
using SharpEngine.Core.Renderer;
using SharpEngine.Core.Utils;

namespace La_Paix_des_Owlks.Widget
{
    internal class ActionBar : SharpEngine.Core.Widget.Widget
    {
        public Color BackgroundColor { get; set; } = new(200, 200, 200, 100);

        public ActionBar(int zLayer = 1000) : base(Vec2.Zero, zLayer)
        {
            AddChild(new ActionBarItem("House", new Vec2(290, 800), "Construit une maison\n\nCout : 1 bois / 1 pierre", new Vec2(250, 60))).Clicked += SwitchBuildHouse;
           
            AddChild(new ActionBarItem("Cross", new Vec2(990, 800), "Détruit une construction", new Vec2(250, 30))).Clicked += SwitchErase;
        }

        public override void Draw()
        {
            base.Draw();

            if(Scene == null)
                return;

            SERender.DrawRectangle(240, 750, 800, 100, BackgroundColor, InstructionSource.UI, ZLayer-1);
            SERender.DrawRectangleLines(new Rect(245, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(345, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(445, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(545, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(645, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(745, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(845, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
            SERender.DrawRectangleLines(new Rect(945, 755, 90, 90), 5, Color.DarkGray, InstructionSource.UI, ZLayer);
        }

        public void SwitchBuildHouse(object? sender, EventArgs e)
        {
            Scene!.GetSceneSystem<ActionSystem>()!.State = ActionState.BuildHouse;
        }

        public void SwitchErase(object? sender, EventArgs e)
        {
            Scene!.GetSceneSystem<ActionSystem>()!.State = ActionState.Erase;
        }
    }
}
