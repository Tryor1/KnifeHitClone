using UnityEngine;
using UnityEngine.Events;

namespace SDA.Input
{
    public class InputSystem
    {
        private UnityAction onClick;

        public void AddListener(UnityAction callback)
        {
            onClick += callback;
        }

        public void RemoveAllListeners()
        {
            onClick = null;
        }
        
        public void UpdateSystem()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space)
            || UnityEngine.Input.GetMouseButtonDown(0)) //0 - left, 1-right
            {
                onClick?.Invoke();
            }
        }
    }
}