using SharpEngine.Core.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks
{
    public static class LPDOConsts
    {
        public static Vec2 RenderSize = new(1280, 920);
        public static Vec2 HalfRenderSize = new(640, 460);
        public static LPDOSave Save { get; private set; } = new LPDOSave();
    }
}
