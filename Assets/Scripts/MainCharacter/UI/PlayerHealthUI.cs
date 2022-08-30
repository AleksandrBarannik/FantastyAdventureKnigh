using System;
using Enemys;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MainCharacter.UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private Player player;

        private void Start()
        {
            player.Health.onDecreaseHealth.AddListener(UpdateUI);
            player.Health.onIncreaseHealth.AddListener(UpdateUI);
        }

        private void UpdateUI()
        {
            healthBar.fillAmount = (float)  player.Health.HealthCount /  player.Health.defaultHealth;
        }

        
    }
}
