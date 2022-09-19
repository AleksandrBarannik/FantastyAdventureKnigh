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
                HandleSoundChange(ref isOnMusic, value, Utils.MusicVolumeKey, musicButton);
                
            });
            
            effectsSlider.onValueChanged.AddListener(delegate(float value)
            {
                AudioController.Instance.Play(Utils.SliderSound);
                HandleSoundChange(ref isOnEffects, value, Utils.EffectVolumeKey,effectsButton);

                if (effectsSlider.value == 0)
                {
                    
                }
            });
            
            musicButton.onClick.AddListener(delegate
            {
                isOnMusic = !isOnMusic;
                HandleSoundClicked(isOnMusic, Utils.MusicVolumeKey, musicSlider, musicButton);
            });
            
            effectsButton.onClick.AddListener(delegate
            {
                isOnEffects = !isOnEffects;
                HandleSoundClicked(isOnEffects, Utils.EffectVolumeKey,effectsSlider, effectsButton);
                
            });
            
            backButton.onClick.AddListener(HandleBackClicked);
        }

        private void HandleBackClicked()
        {
            CheckMenu();
            gameObject.SetActive(false);
        }

        private void HandleSoundClicked(bool isOn, string key, Slider slider, Button button)
        {
            AudioController.Instance.Play(Utils.ButtonSound);
            AudioController.Instance.SetStatus(isOn, key);

            if (isOn)
            {
                slider.value = slider.maxValue;
            }
            else
            {
                slider.value = slider.minValue;
            }
            button.GetComponent<SwitchImageButton>().SetActive(isOn);
        }
        
        private void HandleSoundChange(ref bool active, float value, string key, Button button)
        {
            AudioController.Instance.ChangeVolume(value, key);

            active = Math.Round(value, 3) != 0;
            button.GetComponent<SwitchImageButton>().SetActive(active);
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
