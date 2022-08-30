using System;
using UnityEngine;
using UnityEngine.Events;


namespace MainCharacter.Items.CoinsWalet
{
    public class Wallet : MonoBehaviour
    {
        public static Wallet Instance;
        
        [Header("Events")]
        public UnityEvent onCoinsChange;
        public UnityEvent onCrystalChange;
        
        private int _coins;
        private int _crystals;

        private void Awake()
        {
            Instance = this;
        }

        public int Coins
        {
            get => _coins;
            set
            {
                _coins = value;
                onCoinsChange.Invoke();
            }
        }

        public int Crystals
        {
            get => _crystals;
            set
            {
                _crystals = value;
                onCrystalChange.Invoke();
            }
        }
        
    }
}
