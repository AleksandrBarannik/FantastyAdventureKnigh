using System;
using Common.Menu.LevelMenu.LevelData;
using UnityEngine;

namespace Common.Menu.LevelMenu
{
    public class LevelController : MonoBehaviour
    {
        //Разблокирует уровни , определяет количество звезд после прохождения уровня
        
        public static LevelController Instance;
        
        [HideInInspector]public  int collectCoins = 0;
        
        public LevelDataSO currentLevel;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void UnlockLevel()
        {
            currentLevel.unlockLevel.isLocked = false;
            
            currentLevel = currentLevel.unlockLevel;
        }

        
        public void CheckRate() 
        {
           
            foreach (var coin in StatisticData.Instance.GoldInLevel)
            {
                 if ( coin == null) collectCoins++;
                 
                 if (collectCoins == StatisticData.Instance.GoldInLevel.Length)
                     currentLevel.starsCount = LevelStarsCount.ThreeStar;
                 
                 if (collectCoins < StatisticData.Instance.GoldInLevel.Length
                     && collectCoins >= StatisticData.Instance.GoldInLevel.Length/2)
                     currentLevel.starsCount = LevelStarsCount.TwoStar;
                 
                 
                 if (collectCoins < StatisticData.Instance.GoldInLevel.Length/2)
                     
                     currentLevel.starsCount = LevelStarsCount.OneStar;
                 
                 
                
            }
            
        }
    }
}
