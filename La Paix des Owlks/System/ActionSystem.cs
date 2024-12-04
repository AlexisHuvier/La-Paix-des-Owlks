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

                _ghostHouse.Displayed = false;
                _ghostFarm.Displayed = false;
                _ghostSawmill.Displayed = false;
                _ghostMine.Displayed = false;
                _ghostStatue.Displayed = false;
                _ghostTemple.Displayed = false;
                _eraser.GetComponentAs<SpriteComponent>()!.Displayed = false;

                switch (value)
                {
                    case ActionState.BuildHouse:
                        _ghostHouse.Displayed = true;
                        break;
                    case ActionState.BuildFarm:
                        _ghostFarm.Displayed = true;
                        break;
                    case ActionState.BuildSawmill:
                        _ghostSawmill.Displayed = true;
                        break;
                    case ActionState.BuildMine:
                        _ghostMine.Displayed = true;
                        break;
                    case ActionState.BuildStatue:
                        _ghostStatue.Displayed = true;
                        break;
                    case ActionState.BuildTemple:
                        _ghostTemple.Displayed = true;
                        break;
                    case ActionState.Erase:
                        _eraser.GetComponentAs<SpriteComponent>()!.Displayed = true;
                        break;
                    case ActionState.None:
                        break;
                }
            }
        }

        private readonly GhostHouse _ghostHouse;
        private readonly GhostSawmill _ghostSawmill;
        private readonly GhostFarm _ghostFarm;
        private readonly GhostMine _ghostMine;
        private readonly GhostTemple _ghostTemple;
        private readonly GhostStatue _ghostStatue;
        private readonly Eraser _eraser;
        private ActionState _state;
        private readonly Game _game;
        private SharpEngine.Core.Entity.Entity? erasedEntity = null;

        public ActionSystem(Game game)
        {
            _game = game;
            _ghostHouse = new GhostHouse(Vec2.Zero);
            _ghostFarm = new GhostFarm(Vec2.Zero);
            _ghostSawmill = new GhostSawmill(Vec2.Zero);
            _ghostMine = new GhostMine(Vec2.Zero);
            _ghostStatue = new GhostStatue(Vec2.Zero);
            _ghostTemple = new GhostTemple(Vec2.Zero);
            _eraser = new Eraser();

            State = ActionState.None;
        }

        public void OpenScene()
        {
            _game.AddEntity(_ghostHouse).Load();
            _game.AddEntity(_ghostFarm).Load();
            _game.AddEntity(_ghostSawmill).Load();
            _game.AddEntity(_ghostMine).Load();
            _game.AddEntity(_ghostStatue).Load();
            _game.AddEntity(_ghostTemple).Load();
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
                case ActionState.BuildFarm:
                    UpdateBuildFarm(delta);
                    break;
                case ActionState.BuildSawmill:
                    UpdateBuildSawmill(delta);
                    break;
                case ActionState.BuildMine:
                    UpdateBuildMine(delta);
                    break;
                case ActionState.BuildStatue:
                    UpdateBuildStatue(delta);
                    break;
                case ActionState.BuildTemple:
                    UpdateBuildTemple(delta);
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

        private void UpdateBuildFarm(float delta)
        {
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            _ghostFarm.TransformComponent.Position = mousePosition;

            if (_ghostFarm.CanBuild() && InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                if (LPDOConsts.Save.Wood >= 1 && LPDOConsts.Save.Stone >= 1)
                {
                    LPDOConsts.Save.Wood -= 1;
                    LPDOConsts.Save.Stone -= 1;
                    _game.AddEntity(new Farm(mousePosition)).Load();
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Farm", X = Convert.ToInt32(mousePosition.X), Y = Convert.ToInt32(mousePosition.Y) });
                }

                State = ActionState.None;
            }

        }

        private void UpdateBuildMine(float delta)
        {
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            _ghostMine.TransformComponent.Position = mousePosition;

            if (_ghostMine.CanBuild() && InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                if (LPDOConsts.Save.Wood >= 1 && LPDOConsts.Save.Stone >= 1)
                {
                    LPDOConsts.Save.Wood -= 1;
                    LPDOConsts.Save.Stone -= 1;
                    _game.AddEntity(new Mine(mousePosition)).Load();
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Mine", X = Convert.ToInt32(mousePosition.X), Y = Convert.ToInt32(mousePosition.Y) });
                }

                State = ActionState.None;
            }

        }

        private void UpdateBuildSawmill(float delta)
        {
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            _ghostSawmill.TransformComponent.Position = mousePosition;

            if (_ghostSawmill.CanBuild() && InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                if (LPDOConsts.Save.Wood >= 1 && LPDOConsts.Save.Stone >= 1)
                {
                    LPDOConsts.Save.Wood -= 1;
                    LPDOConsts.Save.Stone -= 1;
                    _game.AddEntity(new Sawmill(mousePosition)).Load();
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Sawmill", X = Convert.ToInt32(mousePosition.X), Y = Convert.ToInt32(mousePosition.Y) });
                }

                State = ActionState.None;
            }
        }

        private void UpdateBuildStatue(float delta)
        {
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            _ghostStatue.TransformComponent.Position = mousePosition;

            if (_ghostStatue.CanBuild() && InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                if (LPDOConsts.Save.Stone >= 2)
                {
                    LPDOConsts.Save.Stone -= 2;
                    LPDOConsts.Save.Peace += 10;
                    _game.AddEntity(new Statue(mousePosition)).Load();
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Statue", X = Convert.ToInt32(mousePosition.X), Y = Convert.ToInt32(mousePosition.Y) });
                }

                State = ActionState.None;
            }
        }

        private void UpdateBuildTemple(float delta)
        {
            var mousePosition = InputManager.GetMousePosition() + (_game.Window!.CameraManager.Position - LPDOConsts.HalfRenderSize);
            _ghostTemple.TransformComponent.Position = mousePosition;

            if (_ghostTemple.CanBuild() && InputManager.IsMouseButtonPressed(SharpEngine.Core.Input.MouseButton.Left))
            {
                if (LPDOConsts.Save.Stone >= 2 && LPDOConsts.Save.Wood >= 2)
                {
                    LPDOConsts.Save.Stone -= 2;
                    LPDOConsts.Save.Wood -= 2;
                    _game.AddEntity(new Temple(mousePosition)).Load();
                    LPDOConsts.Save.Objects.Add(new Object { Type = "Temple", X = Convert.ToInt32(mousePosition.X), Y = Convert.ToInt32(mousePosition.Y) });
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

                    if(erasedEntity.Tag == "Statue")
                        LPDOConsts.Save.Peace -= 5;
                }
                State = ActionState.None;
            }
        }
    }
}
