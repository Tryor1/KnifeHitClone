using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private Button playButton;

        public Button PlayButton => playButton;
    }
}