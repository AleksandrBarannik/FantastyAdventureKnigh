using System;
using UnityEngine;

namespace MainCharacter
{
    public class PlayerPropertiesManager : MonoBehaviour
    {
        public static PlayerPropertiesManager Instance;
        private Player _player => Player.Instance;

        private int _defaultDamage;

        private void Awake()
        {
            Instance = this;
        }

        public void IncreaseDamage(int value, float time)
        {
            _defaultDamage = _player.attackDamage;
            _player.attackDamage += value;
            
            Invoke(nameof(ResetDamage), time);
        }

        private void ResetDamage()
        {
            _player.attackDamage = _defaultDamage;
        }
        
        
    }
}