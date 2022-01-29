using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SDA.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI pointsText;

        [SerializeField] 
        private KnifeElement knifeElementPrefab;

        [SerializeField] 
        private RectTransform knifeElementContent;
        
        private List<KnifeElement> spawnedElements = new List<KnifeElement>();

        private int knifeToDelete;
        
        public void UpdatePoints(int points)
        {
            pointsText.text = points.ToString();
        }

        public void SpawnAmmo(int amount)
        {
            DespawnAmmo();
            
            for (int i = 0; i < amount; ++i)
            {
                var newKnife = Instantiate(knifeElementPrefab, knifeElementContent);
                spawnedElements.Add(newKnife);
                newKnife.MarkAsUnlocked();
            }

            knifeToDelete = -1;
        }

        private void DespawnAmmo()
        {
            for (int i = spawnedElements.Count - 1; i >= 0; i --)
            {
                Destroy(spawnedElements[i].gameObject);
            }
            spawnedElements.Clear();
        }

        public void DecreaseAmmo()
        {
            knifeToDelete++;
            spawnedElements[knifeToDelete].MarkAsLocked();
        }
    }
}