using System;
using UnityEngine;
using UnityEngine.Audio;

namespace CryingOnionTools.AudioTools
{
    public class MixerVolumeController : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField, Range(MinVolume, MaxVolume)] private float volume = 1f;
        [SerializeField] private string parameterExposeName = "";

        public const float MinVolume = 0.0001f;
        public const float MaxVolume = 1f;

        public float Volume => volume;

        public Action<float> onValueChange;


        void Awake()
        {
            volume = audioMixer.GetFloat(parameterExposeName, out float vol) ? DecibelToLinear(vol) : MaxVolume;
        }

        private float LinearToDecibel(float value) => 20f * Mathf.Log10(value);
        private float DecibelToLinear(float dB) => Mathf.Pow(10f, dB / 20f);

        public void ChangeVolume(float value)
        {
            volume = Mathf.Clamp(value, MinVolume, MaxVolume);
            audioMixer.SetFloat(parameterExposeName, LinearToDecibel(volume));
            onValueChange?.Invoke(volume);
        }
    }
}