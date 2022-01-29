using System.Collections;
using System.Collections.Generic;
using SDA.CoreGameplay;
using SDA.Input;
using UnityEngine;
using SDA.UI;
using SDA.Generation;
using SDA.Points;
using UnityEngine.Events;

namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private PointsSystem pointsSystem;

        public GameState(
            GameView gameView, 
            InputSystem inputSystem,
            LevelGenerator levelGenerator, 
            ShieldMovementController shieldMovementController,
            KnifeThrower knifeThrower,
            PointsSystem pointsSystem)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrower = knifeThrower;
            this.pointsSystem = pointsSystem;
        }

        public override void InitState()
        {
            if (gameView != null)
            {
                gameView.ShowView();
            }
            
            pointsSystem.InitSystem();
            PrepareNewShield();
            PrepareNewKnife();
            inputSystem.AddListener(knifeThrower.Throw);
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
            shieldMovementController.UpdateController();
        }

        public override void DestroyState()
        {
            if(gameView!=null)
                gameView.HideView();
            
            inputSystem.RemoveAllListeners();
        }

        private void PrepareNewKnife()
        {
            IncreasePoints();
            var newKnife = levelGenerator.SpawnKnife();
            knifeThrower.SetKnife(newKnife);
        }

        private void IncreasePoints()
        {
            pointsSystem.IncreasePoints();
            gameView.UpdatePoints(pointsSystem.CurrentPoints);
        }

        private void PrepareNewShield()
        {
            UnityAction onShieldHit = gameView.DecreaseAmmo;
            onShieldHit += PrepareNewKnife;
            
            var newShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(newShield, 
                onShieldHit, PrepareNewShield);
            
            gameView.SpawnAmmo(newShield.KnivesToWin);
        }
    }
}