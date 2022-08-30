using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Ставит игру на Pause/Play
namespace Common.ControlMenu
{
    public class PauseHandler : MonoBehaviour
    {
        public static PauseHandler Instance;
        
        [Header("Events")] 
        public UnityEvent onPause;
        public UnityEvent onPlay;

        public Button pauseButton;

        private void Awake()
        {
            Instance = this;
            
            pauseButton.onClick.AddListener(delegate
            {
                Pause();
            });
        }

        /*private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Pause(); //For PC
        }
        */

        public void Pause()
        {
            Time.timeScale = 0;
            
            onPause.Invoke();
        }

        public void Play()
        {
            Time.timeScale = 1;
            onPlay.Invoke();            
        }
    }
}
