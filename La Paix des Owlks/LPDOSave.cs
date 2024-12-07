using SharpEngine.Core.Data.Save;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks
{
    public class LPDOSave
    {
        public int Wood { get; set; } = 0;

        public int Stone { get; set; } = 0;

        public int Food { get; set; } = 0;

        public int Peace { get; set; } = 0;
        public float ValueAgainstIris { get; set; } = 50;

        public Vec2 PlayerPosition { get; set; } = LPDOConsts.HalfRenderSize;

        public List<Object> Objects { get; set; } = [
            new Object() { Type = "Rock", X = 300, Y = 300 },
            new Object() { Type = "Rock", X = 900, Y = 600 },
            new Object() { Type = "Wood", X = 300, Y = 600 },
            new Object() { Type = "Wood", X = 900, Y = 300 },
            new Object() { Type = "Rock", X = 600, Y = 600 },
            new Object() { Type = "Rock", X = 900, Y = 900 },
            new Object() { Type = "Wood", X = 700, Y = 600 },
            new Object() { Type = "Wood", X = 900, Y = 800 },
            new Object() { Type = "Rock", X = 1250, Y = 300 },
            new Object() { Type = "Rock", X = 900, Y = 200 },
            new Object() { Type = "Wood", X = 300, Y = 500 },
            new Object() { Type = "Wood", X = 1000, Y = 300 }
        ];

        public LPDOSave()
        {
            if (!File.Exists("save.lpdo"))
                Save();
            else
                Load();
        }

        public void Load()
        {
            var save = new JsonSave();
            if(File.Exists("save.lpdo"))
                save.Read("save.lpdo");
            Wood = save.GetObjectAs("wood", 0);
            Stone = save.GetObjectAs("stone", 0);
            Food = save.GetObjectAs("food", 0);
            Peace = save.GetObjectAs("peace", 0);
            ValueAgainstIris = save.GetObjectAs<float>("valueAgainstIris", 50);
            Objects = save.GetObjectAs<List<Object>>("objects", [
                new Object() { Type = "Rock", X = 300, Y = 300 },
                new Object() { Type = "Rock", X = 900, Y = 600 },
                new Object() { Type = "Wood", X = 300, Y = 600 },
                new Object() { Type = "Wood", X = 900, Y = 300 },
                new Object() { Type = "Rock", X = 600, Y = 600 },
                new Object() { Type = "Rock", X = 900, Y = 900 },
                new Object() { Type = "Wood", X = 700, Y = 600 },
                new Object() { Type = "Wood", X = 900, Y = 800 },
                new Object() { Type = "Rock", X = 1250, Y = 300 },
                new Object() { Type = "Rock", X = 900, Y = 200 },
                new Object() { Type = "Wood", X = 300, Y = 500 },
                new Object() { Type = "Wood", X = 1000, Y = 300 }
            ]);
            PlayerPosition = save.GetObjectAs("playerPosition", LPDOConsts.HalfRenderSize);
        }

        public void Save()
        {
            DebugManager.Log(SharpEngine.Core.Utils.LogLevel.LogInfo, "GAME: Saving...");
            var save = new JsonSave();
            save.SetObject("wood", Wood);
            save.SetObject("stone", Stone);
            save.SetObject("food", Food);
            save.SetObject("peace", Peace);
            save.SetObject("valueAgainstIris", ValueAgainstIris);
            save.SetObject("objects", Objects);
            save.SetObject("playerPosition", PlayerPosition);
            save.Write("save.lpdo");
            DebugManager.Log(SharpEngine.Core.Utils.LogLevel.LogInfo, "GAME: Saved");
        }

    }

    public class Object
    {
        public required string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}