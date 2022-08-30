using UnityEngine;

namespace MainCharacter.MagicBoutle
{
    public class PowerBottle : MonoBehaviour
    {
        [SerializeField] public int increasePower = 15;
        [SerializeField] public int increaseTime = 5;

        private void IncreasePower()
        {
            PlayerPropertiesManager.Instance.IncreaseDamage(increasePower, increaseTime);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.GetComponent<Player>()) return;
            
            IncreasePower();
            Destroy(gameObject);
        }
    }
}
