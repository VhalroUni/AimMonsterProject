using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource earthSound;
    public List<AudioClip> enemyDeathClips;

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
        PlayEarthSound();
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
            newAudioSource.Play();

            Destroy(newAudioSource, enemyDeathClips[enemyIndex].length);
        }
    }
}
