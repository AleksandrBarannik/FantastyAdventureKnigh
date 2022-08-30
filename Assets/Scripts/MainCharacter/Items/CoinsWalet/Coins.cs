using Common.Audio;
using UnityEngine;

namespace MainCharacter.Items.CoinsWalet
{
    public class Coins : MonoBehaviour
    {
        [SerializeField] private int increaseValue = 50;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.GetComponent<Player>()) return;
            
            AudioController.Instance.Play("Gold");
            Wallet.Instance.Coins += increaseValue;
            Destroy(gameObject);
        }
    }
}

