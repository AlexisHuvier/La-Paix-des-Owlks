
using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;

namespace La_Paix_des_Owlks.Scene
{
    internal class Credits: SharpEngine.Core.Scene
    {
        public Credits()
        {
            AddWidget(new Label(new Vec2(640, 200), "Crédits", "RAYLIB_DEFAULT", fontSize: 50));
            AddWidget(new Label(new Vec2(640, 350), "Développé par:", "RAYLIB_DEFAULT", fontSize: 30));
            AddWidget(new Label(new Vec2(640, 400), "Alexis Huvier (LavaPower)", "RAYLIB_DEFAULT", fontSize: 30));
            AddWidget(new Label(new Vec2(640, 500), "Moteur :", "RAYLIB_DEFAULT", fontSize: 30));
            AddWidget(new Label(new Vec2(640, 550), "SharpEngine", "RAYLIB_DEFAULT", fontSize: 30));
            AddWidget(new Button(new Vec2(640, 700), "Retour", "RAYLIB_DEFAULT", new Vec2(300, 75), fontSize: 30)).Clicked += Back;
        }

        private void Back(object? sender, EventArgs e) => Window!.IndexCurrentScene = Scenes.MainMenu.Id();
    }
}
