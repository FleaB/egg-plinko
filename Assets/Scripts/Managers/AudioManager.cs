using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    float musicVolume;
    float sfxVolume;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }

    public void PlayOnLocation(AudioClip audioClip, Vector3 location)
    {
        AudioSource.PlayClipAtPoint(audioClip, location);
    }
    public void PlayClip(AudioClip audioClip)
    {
        sfxSource.clip = audioClip;
        sfxSource.Play();
    }

    public void PlayMusic(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void SetVolume(float volume, bool isMusicVolume)
	{
        if (isMusicVolume)
        {
            musicVolume = volume / 100;
        }
        else
        {
            sfxVolume = volume / 100;
        }
	}
    public void ApplyVolume()
    {
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
    }
}