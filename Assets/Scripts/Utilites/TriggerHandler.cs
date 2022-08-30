using Enemys;
using Utilites;
using UnityEngine;
using UnityEngine.Events;

namespace Utilites
{
    public class TriggerHandler : MonoBehaviour
    {
        public UnityEvent onTriggerEnter;
        public UnityEvent onTriggerStay;
        public UnityEvent onTriggerExit;

        [Header("What tag in use")] 
        public string[] tags;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!Utils.HasStringInArray(other.tag, tags)) return;
            
            
            onTriggerEnter.Invoke();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!Utils.HasStringInArray(other.tag, tags)) return;
            
            onTriggerStay.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!Utils.HasStringInArray(other.tag, tags)) return;
            
            onTriggerExit.Invoke();
        }

    }
}