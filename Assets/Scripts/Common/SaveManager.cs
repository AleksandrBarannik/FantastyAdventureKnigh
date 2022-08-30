using UnityEngine;
using Utilites;

namespace Common
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance;

        private void Awake()
        {
            Instance = this;
            SetMusicStatus(false);
            SetEffectStatus(false);
        }
    
        public void SetMusicStatus(bool isOn)
        {
            PlayerPrefs.SetInt(Utils.MusicVolumeKey, isOn ? 1 : 0);
        }

        public bool GetMusicStatus() => PlayerPrefs.GetInt(Utils.MusicVolumeKey) == 1;

        public void SetEffectStatus(bool isOn)
        {
            PlayerPrefs.SetInt(Utils.EffectVolumeKey, isOn ? 1 : 0);
        }
        
        public bool GetSoundStatus() => PlayerPrefs.GetInt(Utils.EffectVolumeKey) == 1;
    }
}
