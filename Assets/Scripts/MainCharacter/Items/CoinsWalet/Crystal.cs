using Common.Audio;
using UnityEngine;
using Utilites;

namespace MainCharacter.Items.CoinsWalet
{
    public class Crystal : MonoBehaviour
    {
        [SerializeField] private int increaseValue = 2;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.GetComponent<Player>()) return;

            Wallet.Instance.Crystals += increaseValue;
            AudioController.Instance.Play(Utils.GoldSound);
            Destroy(gameObject);
        }
    }
}
