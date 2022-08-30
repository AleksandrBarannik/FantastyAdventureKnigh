using System;
using Common.Menu.LevelMenu.LevelData;
using UnityEngine;
using UnityEngine.UI;
//Links, Class LevelRate, LoadSceene(on button numberLevel)
namespace Common.Menu.LevelMenu
{
    public enum LevelStarsCount
    {
        OneStar,
        TwoStar,
        ThreeStar
    }

    [Serializable]
    public class LevelRate
    {
        public LevelStarsCount starsCount;
        public GameObject starObject;
    }

    public class Level : MonoBehaviour
    {
        [Header("Properties")]
        public int indexNextLevel;
        
        [Header("Link to objects")]
        public Image avatar;
        public Image levelNumber;
        public GameObject lockedImage;
        [HideInInspector] public LevelDataSO levelData;
        
        [SerializeField] private Button loadLevel;
        public LevelRate[] levelRates;

        
        
        
        private void Start()
        {
            loadLevel.onClick.AddListener(HandleLoadClicked);
        }
        
        private void HandleLoadClicked()
        {
            LevelController.Instance.currentLevel = levelData;
            
            SceneLoader.Instance.LoadScene(indexNextLevel);
            SceneLoader.Instance.slider.gameObject.SetActive(true);
            
        }

        
    }
}
