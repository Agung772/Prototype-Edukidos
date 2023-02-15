using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
 
    public float volumeAudio;

    public Slider volumeSlider;
    public AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    public void VolumeValue(float value)
    {
        volumeAudio = value;
        audioSource.volume = value;
    }

}
