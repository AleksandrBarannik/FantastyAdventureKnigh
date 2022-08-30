using System;
using Common.ControlMenu;
using Common.Menu;
using Common.Menu.LevelMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class FinishLevel : MonoBehaviour
    {
        private bool IsFinish = false;
        private GameObject enemy;

        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                IsFinish = true;
                LoadScreenVictory();
            }
        }

        public void LoadScreenVictory()
        {
            GameStatusWindow.Instance.EnableVictoryScreen();
            

        }
        
        
    }
}
