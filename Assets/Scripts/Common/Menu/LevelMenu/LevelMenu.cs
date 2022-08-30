using Common.ControlMenu;
using UnityEngine;
using UnityEngine.UI;

//Отвечает за действие на  кнопку выхода из LevelMenu
namespace Common.Menu.LevelMenu
{
    public class LevelMenu : MonoBehaviour
    {
        public static LevelMenu Instance;
        
        [SerializeField]
        private Button backButton;
        
        [SerializeField]
        private Button NextButton;
        
        [SerializeField]
        private Button prewievButton;


        private void Awake()
        {
            Instance = this;
            
        }
        private void Start()
        {
            backButton.onClick.AddListener(HandleBackClicked);
            NextButton.onClick.AddListener(HandleNextClicked);
            prewievButton.onClick.AddListener(HandlePrewievClicked);
        }

        private void HandleBackClicked()
        {
            MainMenuController.Instance.EnableMainMenu();
            gameObject.SetActive(false);
        }
        
        private void HandleNextClicked()
        {
            
            LevelMenu.Instance.GetComponent<LevelsWindow>().MoveRight();
        }
        
        private void HandlePrewievClicked()
        {
            LevelMenu.Instance.GetComponent<LevelsWindow>().MoveLeft();
        }
    

    }
}
