using Common.Menu;
using Common.Menu.LevelMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.ControlMenu
{
    public class MainMenuController : MonoBehaviour
    {
        public static MainMenuController Instance;
        
        [SerializeField]
        private MainMenu mainMenu;
        
        [SerializeField]
        private SettingsMenu settingsMenu;
        
        [SerializeField]
        private LevelMenu levelMenu;
        
        
        private void Awake()
        {
            Instance = this;
        }
        
        
        public void Exit()
        {
            Application.Quit();
        }

        public void EnableSettings()
        {
            settingsMenu.gameObject.SetActive(true);
        }
        
        public void EnableLevelMenu()
        {
            levelMenu.gameObject.SetActive(true);
        }
        
        public void EnableMainMenu()
        {
            mainMenu.gameObject.SetActive(true);
        }
        
        
        
        

        
        
    }
}
