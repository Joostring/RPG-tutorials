using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    [SerializeField]AudioMixer audioMixer;
    [SerializeField] TMP_Text masterVolume;
    [SerializeField] TMP_Text sfxVolume;
    [SerializeField] TMP_Text ambienceVolume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume(float volume) 
    { 
      
        
        int volumeToInt = Mathf.Clamp((int)volume, 0, 20);
        masterVolume.text = volumeToInt.ToString();
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume) 
    {
        int volumeToInt = Mathf.Clamp((int)volume,0, 20);
        sfxVolume.text = volumeToInt.ToString();
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
    public void SetAmbienceVolume(float volume) 
    {
        int volumeToInt = Mathf.Clamp((int)volume, 0, 20);
        ambienceVolume.text = volumeToInt.ToString();
        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 20);
    }
}
