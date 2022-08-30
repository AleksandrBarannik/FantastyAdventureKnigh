using UnityEngine;

namespace Common.Audio
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip audioClip;
    
        [Range(0f, 1f)]
        public float volume = 1;

        [HideInInspector]
        public AudioSource audioSource;
    }
}
