using SDA.UI;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Architecture
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private UnityAction transitionToGameState;

        public MenuState(UnityAction transitionToGameState, MenuView menuView)
        {
            this.menuView = menuView;
            this.transitionToGameState = transitionToGameState;
        }

        public override void InitState()
        {
            Debug.Log("INIT MENU");
            
            if(menuView != null)
                menuView.ShowView();
            
            menuView.PlayButton.onClick.AddListener(transitionToGameState);
        }

        public override void UpdateState()
        {
            
        }

        public override void DestroyState()
        {
            if (menuView != null) 
                menuView.HideView();


            menuView.PlayButton.onClick.RemoveAllListeners();
        }
    }
}