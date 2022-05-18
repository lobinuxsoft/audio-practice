using UnityEngine;
using CryingOnionTools.AudioTools;
using CryingOnionTools.ScriptableVariables;
using UnityEngine.Events;

[RequireComponent(typeof(MixerVolumeController))]
public class LoadSaveMixerVolume : MonoBehaviour
{
    [SerializeField] FloatVariable volumeData;
    MixerVolumeController controller;

    public UnityEvent<float> onLoadComplete;

    private void Awake()
    {
        controller = GetComponent<MixerVolumeController>();

        controller.onValueChange += SaveVolume;

        LoadVolume();
    }

    private void OnDestroy()
    {
        if(controller) controller.onValueChange -= SaveVolume;
    }

    private void LoadVolume()
    {
        volumeData.LoadData();
        controller = GetComponent<MixerVolumeController>();
        controller.ChangeVolume(volumeData.Value);
        onLoadComplete?.Invoke(controller.Volume);
    }

    private void SaveVolume(float value)
    {
        volumeData.Value = value;
        volumeData.SaveData();
    }
}
