using Common.ControlMenu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Отвечает за действиz на  кнопки из PauseMenu
namespace Common.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private Button resumeButton;
        
        [SerializeField]
        private Button exitButton;
        
        [SerializeField]
        private Button settingsButton;
        
        [SerializeField]
        private Button restartButton;

        private void Start()
        {
            resumeButton.onClick.AddListener(HandleResumeClicked);
            exitButton.onClick.AddListener(HandleQuitClicked);
            settingsButton.onClick.AddListener(HandleSettingClicked);
            restartButton.onClick.AddListener(HandleRestartClicked);
        }

   
        private void HandleResumeClicked()
        {
            PauseHandler.Instance.Play();
        
        }
    
        private void HandleQuitClicked()
        {
            SceneManager.LoadScene(0);
            PauseHandler.Instance.Play();
        }
    
        private void HandleSettingClicked()
        {
            GameMenuController.Instance.EnableSettings();
            gameObject.SetActive(false);
        }
    
        private void HandleRestartClicked()
        {
            SceneLoader.Instance.ReloadScene();
            PauseHandler.Instance.Play();
        }
    }
}
