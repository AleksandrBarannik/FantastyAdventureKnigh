using UnityEngine;

namespace Common.Menu.LevelMenu.LevelData
{
    //Data for LevelMenu
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Level", order = 1)]
    public class LevelDataSO : ScriptableObject
    { 
        public LevelDataSO unlockLevel;
        
        [Header("Properties")]
        public int indexLevel;
        public bool isLocked = false;
        public LevelStarsCount starsCount;
        
        [Header("Link to objects")]
        public Sprite buttonBackground;
        public Sprite numberLevel;
    }
}
