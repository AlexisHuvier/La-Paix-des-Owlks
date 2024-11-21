using SharpEngine.Core.Data.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks
{
    public class LPDOSave : JsonSave
    {
        public int Wood { 
            get => GetObjectAs("wood", 0); 
            set { 
                SetObject("wood", value); 
                Write("save.lpdo");
            } 
        }

        public int Stone { 
            get => GetObjectAs("stone", 0); 
            set
            {
                SetObject("stone", value);
                Write("save.lpdo");

            }
        }

        public int Food { 
            get => GetObjectAs("food", 0);
            set {
                SetObject("food", value);
                Write("save.lpdo");
            }
        }

        public int Peace { 
            get => GetObjectAs("peace", 0); 
            set {
                SetObject("peace", value);
                Write("save.lpdo");
            } 
        }

        public bool Taken0 { 
            get => GetObjectAs("taken0", false); 
            set {
                SetObject("taken0", value);
                Write("save.lpdo");
            } 
        }

        public bool Taken1 { 
            get => GetObjectAs("taken1", false); 
            set {
                SetObject("taken1", value);
                Write("save.lpdo");
            } 
        }

        public bool Taken2 { 
            get => GetObjectAs("taken2", false); 
            set {
                SetObject("taken2", value);
                Write("save.lpdo");
            } 
        }

        public bool Taken3 { 
            get => GetObjectAs("taken3", false); 
            set {
                SetObject("taken3", value);
                Write("save.lpdo");
            } 
        }

        public List<Batiment> Batiments { 
            get => GetObjectAs("batiments", new List<Batiment>()); 
            set {
                SetObject("batiments", value);
                Write("save.lpdo");
            } 
        }

        public LPDOSave()
        {
            if (!File.Exists("save.lpdo"))
                Write("save.lpdo");
            Read("save.lpdo");
        }

    }

    public class Batiment
    {
        public required string Type { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}