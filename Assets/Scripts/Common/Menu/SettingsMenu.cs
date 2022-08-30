using System;
using Common.Audio;
using Common.ControlMenu;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;
using Utilites;

namespace Common.Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        
        [SerializeField]
        private Button backButton;
        
        [SerializeField]
        private Button musicButton;
        
        [SerializeField]
        private Button effectsButton;
        
        [SerializeField]
        private Slider effectsSlider;
        
        [SerializeField]
        private Slider musicSlider;
        
        [SerializeField]
        private bool isMainMenuWindow = true;
        
        private bool isOnMusic = true;
        private bool isOnEffects = true;

        private void Start()
        {
            musicSlider.onValueChanged.AddListener(delegate(float value)
            {
                HandleSoundChange(value, Utils.MusicVolumeKey);
                
            });
            
            effectsSlider.onValueChanged.AddListener(delegate(float value)
            {
                AudioController.Instance.Play("SliderSound");
                HandleSoundChange(value, Utils.EffectVolumeKey);
            });
            
            musicButton.onClick.AddListener(delegate
            {
                HandleSoundClicked(isOnMusic, Utils.MusicVolumeKey, musicSlider);
                isOnMusic = !isOnMusic;
                
            });
            
            effectsButton.onClick.AddListener(delegate
            {
                HandleSoundClicked(isOnEffects, Utils.EffectVolumeKey,effectsSlider);
                isOnEffects = !isOnEffects;
                
            });
            
            backButton.onClick.AddListener(HandleBackClicked);
        }

        private void HandleBackClicked()
        {
            CheckMenu();
            gameObject.SetActive(false);
        }

        private void HandleSoundClicked(bool isOn, string key, Slider slider)
        {
            AudioController.Instance.Play("ButtonSound");
            AudioController.Instance.SetStatus(isOn, key);
            
            if (isOn)
                slider.value = slider.maxValue;
            else 
                slider.value = slider.minValue;
        }

        private void HandleSoundChange(float value, string key)
        {
            AudioController.Instance.ChangeVolume(value, key);
        }
       
        private void CheckMenu()
        {
            if (isMainMenuWindow)
            {
                MainMenuController.Instance.EnableMainMenu();
            }
            else if (!isMainMenuWindow)
            {
                GameMenuController.Instance.EnablePause();
            }
        }

    }
}
