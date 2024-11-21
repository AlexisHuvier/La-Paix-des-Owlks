using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;

namespace La_Paix_des_Owlks.Scene
{
    internal class MainMenu: SharpEngine.Core.Scene
    {
        public MainMenu()
        {
            AddWidget(new Label(new Vec2(640, 200), "La Paix des Owlks", "RAYLIB_DEFAULT", fontSize: 50));

            AddWidget(new Button(new Vec2(640, 400), "Jouer", "RAYLIB_DEFAULT", new Vec2(300, 75), fontSize: 30)).Clicked += Play;
            AddWidget(new Button(new Vec2(640, 550), "Crédits", "RAYLIB_DEFAULT", new Vec2(300, 75), fontSize: 30)).Clicked += Credits;
            AddWidget(new Button(new Vec2(640, 700), "Quitter", "RAYLIB_DEFAULT", new Vec2(300, 75), fontSize: 30)).Clicked += Quit;
        }

        private void Play(object? sender, EventArgs e) => Window!.IndexCurrentScene = Scenes.Game.Id();
        private void Credits(object? sender, EventArgs e) => Window!.IndexCurrentScene = Scenes.Credits.Id();
        private void Quit(object? sender, EventArgs e) => Window?.Stop();
    }
}
