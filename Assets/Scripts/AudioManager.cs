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

    public AudioClip BGMConnectTheDots;

    public AudioClip sfxScore, sfxGameOver, sfxHoldClick, sfxEnterMinigame, sfxPause, sfxUnpause;


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

    public void SfxScore() { if (sfxScore != null) audioSource.PlayOneShot(sfxScore); }
    public void SfxGameOver() { if (sfxGameOver != null) audioSource.PlayOneShot(sfxGameOver); }
    public void SfxHoldClick() { if (sfxHoldClick != null) audioSource.PlayOneShot(sfxHoldClick); }
    public void SfxEnterMinigame() { if (sfxEnterMinigame != null) audioSource.PlayOneShot(sfxEnterMinigame); }
    public void SfxPause() { if (sfxPause != null) audioSource.PlayOneShot(sfxPause); }
    public void SfxUnpause() { if (sfxUnpause != null) audioSource.PlayOneShot(sfxUnpause); }

}
