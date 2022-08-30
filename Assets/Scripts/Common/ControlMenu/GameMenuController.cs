using System;
using Common.ControlMenu;
using Common.Menu;
using MainCharacter;
using UnityEngine;

namespace Common.ControlMenu
{
    public class GameMenuController : MonoBehaviour
    {
        public static GameMenuController Instance;
        
        [SerializeField]
        private SettingsMenu settingsMenu;
        
        [SerializeField] 
        private PauseMenu pauseMenu;
        
        [SerializeField]
        private GameObject pauseWindow;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PauseHandler.Instance.onPause.AddListener(delegate
            {
                pauseWindow.SetActive(true);
            });
            
            PauseHandler.Instance.onPlay.AddListener(delegate
            {
                pauseWindow.SetActive(false);
            });
            
        }

        public void EnablePause()
        {
            pauseMenu.gameObject.SetActive(true); 
        }
        
        public void EnableSettings()
        {
            settingsMenu.gameObject.SetActive(true); 
        }
        
       
    }
}