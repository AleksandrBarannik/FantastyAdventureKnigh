using Common.Menu.LevelMenu.LevelData;
using UnityEngine;

//Отвечает за генерацию префабов уровней на экране выбора уровней
namespace Common.Menu.LevelMenu
{
    public class LevelsWindow : MonoBehaviour
    {
        [SerializeField]
        private int levelCountInWindow = 7;
        
        [SerializeField]
        private LevelDataSO[] levelsData;
        
        [SerializeField]
        private Level levelPrefab;
        
        [SerializeField]
        private RectTransform layout;

        private int _currentIndex = 0;

        public void Initialize()
        {
            CleanUp();
            for (int i = 0; i < levelCountInWindow; i++)
            {
                CreateItem(levelsData[i]);
                _currentIndex++;
            }
            gameObject.SetActive(true);
        } 

        private void CreateItem(LevelDataSO levelData) //Подменяет спрайты для каждого нового SO
        {
            Level newLevel = Instantiate(levelPrefab, layout);
            newLevel.indexNextLevel = levelData.indexLevel;
            newLevel.avatar.sprite =  levelData.buttonBackground;
            newLevel.levelNumber.sprite = levelData.numberLevel;
            newLevel.levelData = levelData;

            foreach (var levelRate in newLevel.levelRates) // аквтивирует обьекты класса levelRate (сам класс находится в Levels)
            {
                if (levelData.starsCount != levelRate.starsCount) continue;
                if (!levelData.isLocked) levelRate.starObject.SetActive(true);
            }
            
            if (levelData.isLocked) newLevel.lockedImage.SetActive(true);
        }
        
        private void CleanUp()
        {
            for (int i = 0; i < layout.childCount; i++)
            {
                Destroy(layout.GetChild(i).gameObject);
            }
        }

        public void MoveRight()
        {
            CleanUp();

           for (int i = 0; i < levelCountInWindow; i++)
            {
                CreateItem(levelsData[_currentIndex]);
                _currentIndex++;

                if (_currentIndex == levelsData.Length)
                {
                    _currentIndex = 0;
                    return;  
                }
                
            }
        }
        
        public void MoveLeft()
        {
            CleanUp();
            
            
            for (int i = levelsData.Length; i > levelCountInWindow; i--)
            {
                CreateItem(levelsData[_currentIndex]);
                _currentIndex++;
               
                if (_currentIndex >= levelsData.Length)
                {
                    _currentIndex = 0;
                    return;  
                }
                
            }

            
        }

    }
}
