using Common;
using UnityEngine;

namespace MainCharacter.MagicBoutle
{
    public class HealthBoutle : MonoBehaviour
    {
        [SerializeField] public int increaseHealth = 20;
    
        private void RegenerationHealth(int increaseHealth)
        {
            Player.Instance.GetComponent<Health>().IncreaseHealth(increaseHealth);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.GetComponent<Player>()) return;
            
            //other.GetComponent<Health>().IncreaseHealth(increaseHealth);
            RegenerationHealth(increaseHealth);
            Destroy(gameObject);
        }
    }
}
