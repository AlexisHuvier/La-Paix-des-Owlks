using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Scene
{
    public enum Scenes
    {
        MainMenu,
        Credits,
        Game,
        EndGame
    }

    public static class SceneExtensions
    {
        public static int Id(this Scenes scene) => (int)scene;
    }
}
