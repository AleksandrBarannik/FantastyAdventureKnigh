using Common.Audio;
using Common.ControlMenu;
using Common.Menu.LevelMenu;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

        public void EnableVictoryScreen()
        {
            DeactiveButton();
            AudioController.Instance.Play("Win");
            screenVictory.gameObject.SetActive(true); 
            LevelController.Instance.CheckRate();
            LevelController.Instance.UnlockLevel();
           
            onWin.Invoke();
        }
        
        public void EnableLoseScreen()
        {
            DeactiveButton();
            AudioController.Instance.Play("Lose");
            screenLose.gameObject.SetActive(true);
            onLose.Invoke();
        }

        private void DeactiveButton()
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
