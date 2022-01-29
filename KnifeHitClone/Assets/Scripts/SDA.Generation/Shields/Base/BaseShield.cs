using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace SDA.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        private UnityAction onShieldHit;
        private UnityAction onWin;

        [SerializeField] 
        private int knivesToWin;
        public int KnivesToWin => knivesToWin;
        
        [SerializeField] 
        protected ShieldMovementStep[] movementScheme;

        private List<Knife> knivesInShield = new List<Knife>();
        
        public virtual void Initialize(
            UnityAction onShieldHit,
            UnityAction onWinCallback)
        {
            this.onShieldHit = onShieldHit;
            onWin = onWinCallback;
        }

        public abstract void Rotate();

        public virtual void Dispose()
        {
            for (int i = knivesInShield.Count - 1; i >= 0; i--)
            {
                var knife = knivesInShield[i];
                Destroy(knife.gameObject);
                knivesInShield.Remove(knife);
            }
            
            knivesInShield.Clear();
            onShieldHit = null;
            onWin = null;
            
            Destroy(this.gameObject);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            var knife = other.GetComponentInParent<Knife>();
            knife.Rigidbody2D.velocity = Vector2.zero;
            knife.transform.rotation = Quaternion.identity;
            knife.Rigidbody2D.isKinematic = true;
            knife.transform.position = new Vector3(0f,0f,0f);
            knivesInShield.Add(knife);
            knife.transform.SetParent(this.transform);

            onShieldHit.Invoke();
            if (knivesInShield.Count == knivesToWin)
            {
                onWin.Invoke();
            }
        }
    }
}