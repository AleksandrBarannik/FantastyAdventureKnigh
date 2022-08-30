using UnityEngine;

namespace Common.Menu.LevelMenu.LevelData
{
    //Data for CheckRate
    public class StatisticData : MonoBehaviour
    {
        [HideInInspector]
        public static StatisticData Instance;
    
    
        [SerializeField]
        private GameObject [] _goldInLevel;
        public GameObject[] GoldInLevel => _goldInLevel;
        
        [SerializeField]
        private GameObject[] _enemyInLevel;
        public GameObject[] EnemyInLevel => _enemyInLevel;
    
        private void Awake()
        {
            Instance = this;
        }
    }
}
