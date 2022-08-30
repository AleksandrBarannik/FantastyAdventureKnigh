using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utilites
{
    public class CollisionHandler : MonoBehaviour
    {
        public UnityEvent onCollisionEnter;
        public UnityEvent onCollisionStay;
        public UnityEvent onCollisionExit;
        
        [Header("What tag in use")] 
        public string[] tags;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (Utils.HasStringInArray(transform.tag, tags)) return;
            
            onCollisionEnter.Invoke();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (Utils.HasStringInArray(transform.tag, tags)) return;
            
            onCollisionStay.Invoke();
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (Utils.HasStringInArray(transform.tag, tags)) return;
            
            onCollisionExit.Invoke();
        }
    }
}
