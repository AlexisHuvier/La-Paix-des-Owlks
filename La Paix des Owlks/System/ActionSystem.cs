using La_Paix_des_Owlks.Entity;
using La_Paix_des_Owlks.Utils;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core;
using SharpEngine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_Paix_des_Owlks.Scene;
using SharpEngine.Core.Component;
using SharpEngine.AetherPhysics;

namespace La_Paix_des_Owlks.System
{
    internal class ActionSystem : ISceneSystem
    {

        public ActionState State {
            get => _state;
            set
            {
                _state = value;
                switch (value)
                {
                    case ActionState.BuildHouse:
                        _ghostHouse.Displayed = true;
                        break;
                    case ActionState.Erase:
                        _ghostHouse.Displayed = false;
                        break;
                    case ActionState.None:
                        _ghostHouse.Displayed = false;
                        break;
                }
            }
        }

        private readonly GhostHouse _ghostHouse;
        private ActionState _state;
        private readonly Game _game;

        public ActionSystem(Game game)
        {
            _game = game;
            _ghostHouse = new GhostHouse(Vec2.Zero);
            State = ActionState.None;
        }

        public void OpenScene()
        {
            _game.AddEntity(_ghostHouse).Load();
        }

        public void CloseScene()
        {
        }

        public void Load()
        {
        }

        public void Unload()
        {
        }

        public void Update(float delta)
        {
            switch(State) {
                case ActionState.BuildHouse:
                    UpdateBuildHouse(delta);
                    break;
                case ActionState.Erase:
                    UpdateErase(delta);
                    break;
            }
        }

        public void Draw()
        {

        }

        private void UpdateBuildHouse(float delta)
        {
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - new Vec2(640, 460));
            _ghostHouse.TransformComponent.Position = mousePosition;

            if (_ghostHouse.CanBuild() && InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                _game.AddEntity(new House(mousePosition)).Load();
                LPDOConsts.Save.Objects.Add(new Object { Type = "House", X = Convert.ToInt32(mousePosition.X), Y = Convert.ToInt32(mousePosition.Y) });
            }

        }

        private void UpdateErase(float delta)
        {
        }
    }
}
