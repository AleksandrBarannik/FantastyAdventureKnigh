using Common.Audio;
using Common.ControlMenu;
using UnityEngine;
using UnityEngine.UI;
using Utilites;

//Отвечает за действиz на  кнопки из MainMenu
namespace Common.Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;
        
        [SerializeField]
        private Button levelButton;
        
        [SerializeField]
        private Button quitButton;
        
        [SerializeField]
        private Button settingsButton;
        
        [SerializeField]
        private Button soundButton;

        private void Start()
        {
            startButton.onClick.AddListener(HandleStartClicked);
            levelButton.onClick.AddListener(HandleLevelClicked);
            quitButton.onClick.AddListener(HandleQuitClicked);
            settingsButton.onClick.AddListener(HandleSettingClicked);
            soundButton.onClick.AddListener(HandleSoundClicked);
        }

        private void HandleStartClicked()
        {
            AudioController.Instance.Play(Utils.ButtonSound);
            gameObject.SetActive(false);
            SceneLoader.Instance.slider.gameObject.SetActive(true);
            SceneLoader.Instance.LoadScene(1);
            
            
        }
        private void HandleLevelClicked()
        {
            AudioController.Instance.Play(Utils.ButtonSound);
            MainMenuController.Instance.EnableLevelMenu();
            gameObject.SetActive(false);
        }
    
        private void HandleQuitClicked()
        {
            AudioController.Instance.Play(Utils.ButtonSound);
            MainMenuController.Instance.Exit();
        }
    
        private void HandleSettingClicked()
        {
            AudioController.Instance.Play(Utils.ButtonSound);
            MainMenuController.Instance.EnableSettings();
            gameObject.SetActive(false);
        }
    
        private void HandleSoundClicked()
        {
            //AudioController.Instance.SetSoundStatus(true);
        }

    }
}
