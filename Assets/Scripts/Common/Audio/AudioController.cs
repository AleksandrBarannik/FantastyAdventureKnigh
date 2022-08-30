using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Common.Audio
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance;
        
        [SerializeField]
        private AudioMixerGroup audioMixer;

        [SerializeField]
        private Sound[] sounds;
       
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            foreach (Sound sound in sounds)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();
                sound.audioSource.clip = sound.audioClip;

                sound.audioSource.volume = sound.volume;
                sound.audioSource.playOnAwake = false;

                sound.audioSource.outputAudioMixerGroup = audioMixer;
            
            }
        }

        public void Play(string clipName)
        {
            Array.Find(sounds, sound => sound.name == clipName).audioSource.Play();
        }
        
        public void Stop(string clipName)
        {
            Array.Find(sounds, sound => sound.name == clipName).audioSource.Stop();
        }
        
        
        public void ChangeVolume(float volume, string key)
        {
            float value = Mathf.Log10(volume)*30;
            audioMixer.audioMixer.SetFloat(key, value);
        }
        
       
        public void SetStatus(bool isOn, string key)
        {
            audioMixer.audioMixer.SetFloat(key, isOn ? 0 : -80);
        }
       
        
       
    }
}
