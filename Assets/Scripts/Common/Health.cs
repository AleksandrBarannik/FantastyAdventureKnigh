using UnityEngine;
using UnityEngine.Events;

//Общий скрипт здоровья для врагов  и главного героя
namespace Common
{
    public class Health : MonoBehaviour
    {
        public int defaultHealth = 10;

        public UnityEvent onIncreaseHealth;
        public UnityEvent onDecreaseHealth;
        public UnityEvent onZeroHealth;

        public int HealthCount => _health;
    
        private int _health = 0;

        private void Start()
        {
            _health = defaultHealth;
        }

        public void IncreaseHealth(int value)
        {
            _health += value;
        
            onIncreaseHealth.Invoke();
        }
    
        public void DecreaseHealth(int value)
        {
            _health -= value;
        
            onDecreaseHealth.Invoke();

            if (_health <= 0)
            {
                onZeroHealth.Invoke();
            }
        }
       
    }
}
