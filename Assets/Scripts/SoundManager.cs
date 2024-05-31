using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource earthSound;
    public List<AudioClip> enemyDeathClips;
    [Range(1, 100)]
    public int volume = 100; // Nueva variable pública para controlar el volumen

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetVolume(volume); // Establece el volumen inicial
        PlayEarthSound();
    }

    public void SetVolume(int newVolume)
    {
        volume = Mathf.Clamp(newVolume, 1, 100); // Asegura que el volumen esté entre 1 y 100
        float adjustedVolume = volume / 100f; // Convierte el volumen a un valor entre 0.01 y 1
        if (earthSound != null)
        {
            earthSound.volume = adjustedVolume;
        }
    }

    public void PlayEarthSound()
    {
        if (earthSound != null)
        {
            earthSound.Play();
        }
    }

    public void PlayEnemyDeathSound(int enemyIndex)
    {
        if (enemyDeathClips != null && enemyIndex >= 0 && enemyIndex < enemyDeathClips.Count)
        {
            AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = enemyDeathClips[enemyIndex];
            newAudioSource.volume = volume / 100f; // Ajusta el volumen del nuevo AudioSource
            newAudioSource.Play();

            Destroy(newAudioSource, enemyDeathClips[enemyIndex].length);
        }
    }
}
