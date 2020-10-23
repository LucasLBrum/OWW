using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;



public class GameConfig : MonoBehaviour
{
    public static GameConfig singleton;
    public Slider audioVolumeSlider = null;
    public Slider musicVolumeSlider = null;

    public Slider sensitivitySliderX = null;
    public Slider sensitivitySliderY = null;
    public List<AudioSource> audios;
    public AudioSource gunAudio;
    public AudioSource selectedAudio;
    public AudioSource musicAudio;

    public float speedX;
    public float speedY;
    public float volumeAudios;
    public float volumeMusic = 1;


    public CinemachineFreeLook freeLookCamera = null;//componente da cinemachine 


    public void ChangeSensitivity()
    {
        speedX = sensitivitySliderX.value;
        speedY = sensitivitySliderY.value;
    }

    public void ChangeVolume()
    {
        volumeAudios = audioVolumeSlider.value;

        if(gunAudio != null)
        {
            gunAudio.volume = volumeAudios;
        }
        selectedAudio.volume = volumeAudios;
        for (int i = 0; i < audios.Count; i++)
        {
            audios[i].volume = volumeAudios;
        }
    }

    public void ChangeVolumeMusic()
    {
        volumeMusic = musicVolumeSlider.value;
        musicAudio.volume = volumeMusic;
    }

    private void Awake()
    {
        NoDestroy();//singleton
    }

    void NoDestroy()//criando singleton
    {
        //Faz com que o game object que possui esta classe não seja destruído ao trocar de cena
        DontDestroyOnLoad(gameObject); 

        if (singleton == null && singleton != this)
        {
            singleton = this;
            //Faz com que o game object que possui esta classe não seja destruído ao trocar de cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// Called when the mouse enters the GUIElement or Collider.
    /// </summary>
    void OnMouseEnter()
    {
        selectedAudio.Play();
    }
}
