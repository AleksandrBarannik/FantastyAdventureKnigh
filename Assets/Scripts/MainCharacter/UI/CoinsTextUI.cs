using MainCharacter.Items.CoinsWalet;
using TMPro;
using UnityEngine;

namespace MainCharacter.UI
{
    public class CoinsTextUI : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            if (!Wallet.Instance) return;
            
            Wallet.Instance.onCoinsChange.AddListener(UpdateText);
            
            UpdateText();
        }

        private void UpdateText()
        {
            int coinsCount = Wallet.Instance.Coins;
            _text.text = coinsCount.ToString();
        }
    }
}
