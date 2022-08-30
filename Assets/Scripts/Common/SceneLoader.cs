using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Common
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;
        public GameObject loadingScreen;
        public Slider slider;
        public TextMeshProUGUI textMeshPro;
        
        private void Awake()
        {
            Instance = this;
        }

        public void LoadScene(int indexLevel)
        {
            StartCoroutine(LoadAsync(indexLevel));
            
        }
        
        public void LoadNextLevel()
        {
            StartCoroutine(LoadAsync(SceneManager.GetActiveScene().buildIndex + 1));
            

        }

        
        public void ReloadScene()
        {
            StartCoroutine(LoadAsync(SceneManager.GetActiveScene().buildIndex));
        }
        
        IEnumerator LoadAsync(int indexLevel)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(indexLevel);
            
            loadingScreen.SetActive(true);
            while (!operation.isDone )
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                textMeshPro.text = "Loading... " + progress * 100f + "%";
                yield return null;
            }
        }
    }
}
