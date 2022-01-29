using SDA.Generation;
using UnityEngine.Events;

namespace SDA.CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyActiveShield;

        public void InitializeShield(
            BaseShield newShield,
            UnityAction onShieldHit,
            UnityAction onWinCallback)
        {
            if(currentlyActiveShield != null)
                currentlyActiveShield.Dispose();

            currentlyActiveShield = newShield;
            currentlyActiveShield.Initialize(onShieldHit,
                onWinCallback);
        }

        public void UpdateController()
        {
            if(currentlyActiveShield != null)
                currentlyActiveShield.Rotate();
        }
    }
}