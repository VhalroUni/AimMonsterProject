using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip slot1;
    public AudioClip slot2;
    public AudioClip slot3;
    public AudioClip slot4;
    public AudioClip slot5;
    public AudioClip slot6;
    public AudioClip slot7;
    public AudioClip slot8;
    public AudioClip slot9;
    public AudioClip slot10;
    public AudioClip slot11;
    public AudioClip slot12;
    public AudioClip slot13;
    public AudioClip slot14;
    public AudioClip slot15;
    public AudioClip slot16;
    public AudioClip slot17;
    public AudioClip slot18;

    private AudioSource audioSource;
    private AudioClip[] slots;
    private int currentTrackIndex;
    private bool isSlot10to18Mode = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slots = new AudioClip[] { slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9, slot10, slot11, slot12, slot13, slot14, slot15, slot16, slot17, slot18 };

        PlayRandomTrackFromSlot1To9();
    }

    void Update()
    {
        CheckForKeyPress();
    }

    void PlayRandomTrackFromSlot1To9()
    {
        currentTrackIndex = Random.Range(0, 9); // Aleatorio entre 0 y 8 (slots 1 a 9)
        PlayCurrentTrack();
    }

    void PlayCurrentTrack()
    {
        if (slots[currentTrackIndex] != null)
        {
            audioSource.clip = slots[currentTrackIndex];
            audioSource.Play();
            StartCoroutine(WaitForTrackToEnd());
        }
    }

    IEnumerator WaitForTrackToEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        PlayNextTrack();
    }

    void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % (isSlot10to18Mode ? 18 : 9);
        PlayCurrentTrack();
    }

    void CheckForKeyPress()
    {
        if (Input.GetKeyDown("0"))
        {
            isSlot10to18Mode = !isSlot10to18Mode;
            PlayRandomTrackFromSlot1To9();
        }

        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                currentTrackIndex = (isSlot10to18Mode ? i + 8 : i - 1); // Ajustar índice para slots 10-18 o 1-9
                PlayCurrentTrack();
                break;
            }
        }
    }
}