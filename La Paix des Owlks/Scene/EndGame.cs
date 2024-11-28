using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Scene
{
    internal class EndGame: SharpEngine.Core.Scene
    {
        public EndGame()
        {
            AddWidget(new Label(new SharpEngine.Core.Math.Vec2(LPDOConsts.HalfRenderSize.X, LPDOConsts.HalfRenderSize.Y - 100), "", "RAYLIB_DEFAULT", fontSize: 40));
            AddWidget(new Label(new SharpEngine.Core.Math.Vec2(LPDOConsts.HalfRenderSize.X, LPDOConsts.HalfRenderSize.Y + 100), "Relancez pour rejouer !", "RAYLIB_DEFAULT", fontSize: 40));
        }

        public override void OpenScene()
        {
            base.OpenScene();

            GetWidgetsAs<Label>()[0].Text = LPDOConsts.Save.ValueAgainstIris <= 0 ? "Vous avez perdu..." : "Vous avez gagné !";

            if (File.Exists("save.lpdo"))
                File.Delete("save.lpdo");
            LPDOConsts.Save.Load();
        }

        public void Rejouer()
        {
            Window!.IndexCurrentScene = Scenes.Game.Id();
        }
    }
}
