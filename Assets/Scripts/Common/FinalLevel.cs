using System;
using Common.ControlMenu;
using Common.Menu;
using Common.Menu.LevelMenu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class FinalLevel : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneLoader.Instance.LoadScene(0);

            }
        }



    }
}