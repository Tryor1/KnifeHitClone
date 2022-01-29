using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SDA.Generation
{
    public class LevelGenerator : MonoBehaviour
    {
        [Header("Shield")]
        [SerializeField]
        private Transform shieldPos;
        
        [SerializeField] 
        private BaseShield shieldPrefab;

        [SerializeField] 
        private Transform shieldRoot;
        
        [Header("Knife")]
        [SerializeField]
        private Transform knifePos;

        [SerializeField] 
        private Knife knifePrefab;

        [SerializeField] 
        private Transform knifeRoot;

        
        public BaseShield SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, 
                shieldPos.position, shieldPos.rotation);
            
            shieldObj.transform.SetParent(shieldRoot);
            
            return shieldObj;
        }
        
        public Knife SpawnKnife()
        {
            var knifeObj = Instantiate(knifePrefab, 
                knifePos.position, knifePos.rotation);
            
            knifeObj.transform.SetParent(knifeRoot);
            return knifeObj;
        }
    }
}
