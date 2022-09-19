using Common.Audio;
using Common.ControlMenu;
using Common.Menu.LevelMenu;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilites;

namespace Common.Menu
{  // Отвчает за экран победы и поражения
    public class GameStatusWindow : MonoBehaviour
    {
        public static GameStatusWindow Instance;

        [Header("Event")] 
        public UnityEvent onWin;
        public UnityEvent onLose;
        
        [Header("Objects links")]
        
        [SerializeField]
        private Button nextLevelButton;
        
        [SerializeField]
        private Button restartButtonWiner;
        
        [SerializeField]
        private Button restartButtonLose;
        
        [SerializeField]
        private Button buttonLoadMainMenu;
        
        
        [SerializeField]
        private GameObject screenVictory;
        
        [SerializeField]
        private GameObject screenLose;

        [SerializeField] [Tooltip("Джостик и кнопки прыжка и атаки")]
        private GameObject[] playButtons;

        private void Awake()
        {
            Instance = this;
        }
        
        private void Start()
        {
            nextLevelButton.onClick.AddListener(HandleNextLevelClicked);
            restartButtonWiner.onClick.AddListener(HandleRestartClicked);
            restartButtonLose.onClick.AddListener(HandleRestartClicked);
            buttonLoadMainMenu.onClick.AddListener(HandleLoadMainMenuClicked);
        }

        private void HandleRestartClicked()
        {
            SceneLoader.Instance.ReloadScene();
            PauseHandler.Instance.Play();
            ActiveButton();

        }

        private void HandleNextLevelClicked()
        {
            SceneLoader.Instance.LoadNextLevel();
            PauseHandler.Instance.Play();
            ActiveButton();
        }
        
        private void HandleLoadMainMenuClicked()
        {
            SceneLoader.Instance.LoadScene(0);
            
        }

        public void EnableVictoryScreen()
        {
            DeactiveButton();
            AudioController.Instance.Play(Utils.WinSound);
            screenVictory.gameObject.SetActive(true); 
            LevelController.Instance.CheckRate();
            LevelController.Instance.UnlockLevel();
           
            onWin.Invoke();
        }
        
        public void EnableLoseScreen()
        {
            DeactiveButton();
            AudioController.Instance.Play(Utils.LoseSound);
            screenLose.gameObject.SetActive(true);
            onLose.Invoke();
        }

        private void DeactiveButton()//Деактивацтя кнопок прыжка и атаки
        {
            foreach (var button in playButtons)
            {
                button.SetActive(false);
            }
        }
        
        private void ActiveButton()
        {
            foreach (var button in playButtons)
            {
                button.SetActive(true);
            }
        }
        
        

    }
}
