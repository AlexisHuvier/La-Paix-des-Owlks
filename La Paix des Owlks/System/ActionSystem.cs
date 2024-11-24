﻿using La_Paix_des_Owlks.Entity;
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
using SharpEngine.Core.Entity;

namespace La_Paix_des_Owlks.System
{
    internal class ActionSystem : ISceneSystem
    {
        public ActionState State {
            get => _state;
            set
            {
                _state = value;
                if (erasedEntity != null)
                    erasedEntity.GetComponentAs<SpriteComponent>()!.TintColor = Color.White;
                erasedEntity = null;

                switch (value)
                {
                    case ActionState.BuildHouse:
                        _ghostHouse.Displayed = true;
                        _eraser.GetComponentAs<SpriteComponent>()!.Displayed = false;
                        break;
                    case ActionState.Erase:
                        _ghostHouse.Displayed = false;
                        _eraser.GetComponentAs<SpriteComponent>()!.Displayed = true;
                        break;
                    case ActionState.None:
                        _ghostHouse.Displayed = false;
                        _eraser.GetComponentAs<SpriteComponent>()!.Displayed = false;
                        break;
                }
            }
        }

        private readonly GhostHouse _ghostHouse;
        private readonly Eraser _eraser;
        private ActionState _state;
        private readonly Game _game;
        private SharpEngine.Core.Entity.Entity? erasedEntity = null;

        public ActionSystem(Game game)
        {
            _game = game;
            _ghostHouse = new GhostHouse(Vec2.Zero);
            _eraser = new Eraser();

            State = ActionState.None;
        }

        public void OpenScene()
        {
            _game.AddEntity(_ghostHouse).Load();
            _game.AddEntity(_eraser).Load();
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
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            _ghostHouse.TransformComponent.Position = mousePosition;

            if (_ghostHouse.CanBuild() && InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                if (LPDOConsts.Save.Wood >= 1 && LPDOConsts.Save.Stone >= 1)
                {
                    LPDOConsts.Save.Wood -= 1;
                    LPDOConsts.Save.Stone -= 1;
                    _game.AddEntity(new House(mousePosition)).Load();
                    LPDOConsts.Save.Objects.Add(new Object { Type = "House", X = Convert.ToInt32(mousePosition.X), Y = Convert.ToInt32(mousePosition.Y) });
                }

                State = ActionState.None;
            }

        }

        private void UpdateErase(float delta)
        {
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            _eraser.GetComponentAs<TransformComponent>()!.Position = mousePosition;

            if(erasedEntity != null)
                erasedEntity.GetComponentAs<SpriteComponent>()!.TintColor = Color.White;
            erasedEntity = _eraser.GetErasedEntity();
            if (erasedEntity != null)
                erasedEntity.GetComponentAs<SpriteComponent>()!.TintColor = Color.Red;

            if (InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                if(erasedEntity != null)
                {
                    LPDOConsts.Save.Objects.RemoveAll(obj =>
                        obj.X == Convert.ToInt32(erasedEntity.GetComponentAs<TransformComponent>()!.Position.X) &&
                        obj.Y == Convert.ToInt32(erasedEntity.GetComponentAs<TransformComponent>()!.Position.Y) &&
                        obj.Type == erasedEntity.Tag
                    );

                    var system = _game.GetSceneSystem<PhysicsSystem>()!;
                    if (system.GetBodyForEntity(erasedEntity) is { } body)
                        system.RemoveBody(body, true);
                    _game.RemoveEntity(erasedEntity, true);
                }
                State = ActionState.None;
            }
        }
    }
}
