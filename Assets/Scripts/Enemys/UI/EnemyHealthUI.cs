using System;
using Enemys;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MainCharacter
{
    public class EnemyHealthUI : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private Enemy enemy;

        private void Start()
        {
            enemy.Health.onDecreaseHealth.AddListener(UpdateUI);
            enemy.Health.onIncreaseHealth.AddListener(UpdateUI);
        }

        private void UpdateUI()
        {
            healthBar.fillAmount = (float)  enemy.Health.HealthCount /  enemy.Health.defaultHealth;
        }

        
    }
}
