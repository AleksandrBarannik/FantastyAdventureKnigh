using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Common.ControlMenu
{
    public class SwitchImageButton : MonoBehaviour
    {
        [Header("Events")] 
        public UnityEvent onActivated;
        public UnityEvent onDeactivated;
        
        public Sprite disabledSprite;
        public Sprite enabledSprite;
        
        private bool isOn = true;
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            _image.sprite = enabledSprite;
        }

       
        public void SetActive(bool value)
        {
            isOn = value;
            _image.sprite = isOn ? enabledSprite : disabledSprite;
            if ( isOn) onActivated.Invoke();
            else onDeactivated.Invoke();
        }
    }
}