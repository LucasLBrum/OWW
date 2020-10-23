using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class ChangeGameConfigScene : MonoBehaviour
{
    public Slider sensitivityX;
    public Slider sensitivityY;
    public Slider volumeSlider;
    public Slider MusicSlider;

    public List<AudioSource> audios;
    public AudioSource selectedAudio;
    public AudioClip music;


    public bool winchesterScene;

    void Start()
    {
        if(winchesterScene == true)
        {
            GameConfig.singleton.freeLookCamera = Camera.main.GetComponentInChildren<CinemachineFreeLook>();
            sensitivityY.value = GameConfig.singleton.speedY;
            sensitivityX.value = GameConfig.singleton.speedX;
            GameConfig.singleton.audios.Clear();
            GameConfig.singleton.audios = audios;
            selectedAudio = GameConfig.singleton.selectedAudio;
            GameConfig.singleton.musicVolumeSlider = MusicSlider;
            MusicSlider.value = GameConfig.singleton.volumeMusic;
            GameConfig.singleton.musicAudio.clip = music;
            GameConfig.singleton.musicAudio.Play();

            GameConfig.singleton.sensitivitySliderX = sensitivityX;
            GameConfig.singleton.sensitivitySliderY = sensitivityY;
            GameConfig.singleton.audioVolumeSlider = volumeSlider;

            volumeSlider.value = GameConfig.singleton.volumeAudios;
            return;
        }
       
        GameConfig.singleton.musicAudio.clip = music;
        GameConfig.singleton.musicAudio.Play();
    }

    public void ChangeSensitivityValueX()
    {
        GameConfig.singleton.ChangeSensitivity();
    }

    public void ChangeVolume()
    {
        GameConfig.singleton.ChangeVolume();
    }

    public void ChangeVolumeMusic()
    {
        GameConfig.singleton.ChangeVolumeMusic();
    }

    public void PlaySelectedAudio()
    {
        selectedAudio.Play();
    }
}
