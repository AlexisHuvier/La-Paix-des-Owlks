using ImGuiNET;
using La_Paix_des_Owlks.Debug;
using La_Paix_des_Owlks.Entity;
using La_Paix_des_Owlks.Scene;
using Raylib_cs;
using SharpEngine.Core;
using SharpEngine.Core.Manager;

Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);

var window = new Window(1280, 920, "La Paix des Owlks", SharpEngine.Core.Utils.Color.CornflowerBlue, null, true, true, true);



#region Debug Management
DebugExtensions.AddConsoleCommands();
#endregion

#region Load Assets
window.TextureManager.AddTexture("bg", "Resource/Image/BG.png");

window.TextureManager.AddTexture("Jan", "Resource/Image/Jan.png");

window.TextureManager.AddTexture("Rock", "Resource/Image/Rock.png");
window.TextureManager.AddTexture("Wood", "Resource/Image/Wood.png");

window.TextureManager.AddTexture("House", "Resource/Image/Maison.png");
#endregion

#region Load Scenes and Launch
window.AddScene(new MainMenu());
window.AddScene(new Credits());
window.AddScene(new Game());

window.IndexCurrentScene = Scenes.MainMenu.Id();
window.Run();
#endregion