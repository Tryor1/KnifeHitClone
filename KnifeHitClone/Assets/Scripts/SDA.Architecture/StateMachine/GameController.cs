using SDA.CoreGameplay;
using SDA.Generation;
using SDA.Input;
using SDA.UI;
using UnityEngine;
using UnityEngine.Events;
using SDA.Points;

namespace SDA.Architecture
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MenuView menuView;
        
        [SerializeField]
        private GameView gameView;

        [SerializeField] 
        private LevelGenerator levelGenerator;

        private InputSystem inputSystem;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private PointsSystem pointsSystem;
        
        private MenuState menuState;
        private GameState gameState;
        
        private BaseState currentlyActiveState;

        private UnityAction toGameStateTransition;

        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);
            
            inputSystem = new InputSystem();
            shieldMovementController = new ShieldMovementController();
            knifeThrower = new KnifeThrower();
            pointsSystem = new PointsSystem();
            
            menuState = new MenuState(toGameStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem, levelGenerator, 
                shieldMovementController, knifeThrower, pointsSystem);
            
            ChangeState(menuState);
        }

        private void Update()
        {
            currentlyActiveState?.UpdateState();
        }

        private void OnDestroy()
        {
            
        }

        private void ChangeState(BaseState newState)
        {
            currentlyActiveState?.DestroyState();
            currentlyActiveState = newState;
            currentlyActiveState?.InitState();
        }
    }
}