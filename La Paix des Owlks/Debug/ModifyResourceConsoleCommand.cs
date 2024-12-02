using SharpEngine.Core;
using SharpEngine.Core.Utils.SeImGui;
using SharpEngine.Core.Utils.SeImGui.ConsoleCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Paix_des_Owlks.Debug
{
    internal class ModifyResourceConsoleCommand : ISeImGuiConsoleCommand
    {
        public string Command => "modifyResource";

        public void Process(string[] args, SeImGuiConsole console, Window window)
        {
            if(args.Length != 2)
            {
                console.AddText("Usage: modifyResource <resource> <value>");
                return;
            }

            if (!int.TryParse(args[1], out int value))
            {
                console.AddText("Invalid value");
                return;
            }

            switch (args[0])
            {
                case "wood":
                    LPDOConsts.Save.Wood = value;
                    console.AddText($"Wood: {LPDOConsts.Save.Wood}");
                    break;
                case "rock":
                    LPDOConsts.Save.Stone = value;
                    console.AddText($"Rock: {LPDOConsts.Save.Stone}");
                    break;
                case "food":
                    LPDOConsts.Save.Food = value;
                    console.AddText($"Food: {LPDOConsts.Save.Food}");
                    break;
                case "peace":
                    LPDOConsts.Save.Peace = value;
                    console.AddText($"Peace: {LPDOConsts.Save.Peace}");
                    break;
                case "jan":
                    LPDOConsts.Save.ValueAgainstIris = value;
                    console.AddText($"Jan: {LPDOConsts.Save.ValueAgainstIris}");
                    break;
                default:
                    console.AddText("Invalid resource");
                    break;
            }
        }
    }
}
