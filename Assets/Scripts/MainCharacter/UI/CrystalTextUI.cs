using MainCharacter.Items.CoinsWalet;
using TMPro;
using UnityEngine;

namespace MainCharacter.UI
{
    public class CrystalTextUI : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            if (!Wallet.Instance) return;
            
            Wallet.Instance.onCrystalChange.AddListener(UpdateText);
            
            UpdateText();
        }

        private void UpdateText()
        {
            int _crystalCount = Wallet.Instance.Crystals;
            _text.text = _crystalCount.ToString();
        }
    }
}
