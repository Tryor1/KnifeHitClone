using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class KnifeElement : MonoBehaviour
    {
        [SerializeField] 
        private Image image;

        public void MarkAsUnlocked()
        {
            image.color = Color.white;
        }

        public void MarkAsLocked()
        {
            image.color = Color.black;
        }
    }
}