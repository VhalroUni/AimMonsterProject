using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de importar este namespace

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
    //dont destroy on load
    [Range(1, 100)]
    public int volume = 100; // Nueva variable pública para controlar el volumen

    private AudioSource audioSource;
    private AudioClip[] slots;
    private int currentTrackIndex;
    private bool isSlot10to18Mode = false;

    private static MusicManager instance; // Singleton instance

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slots = new AudioClip[] { slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8, slot9, slot10, slot11, slot12, slot13, slot14, slot15, slot16, slot17, slot18 };

        SetVolume(volume); // Establece el volumen inicial
        PlayRandomTrackFromSlot1To9();

        SceneManager.sceneLoaded += OnSceneLoaded; // Suscribirse al evento de cambio de escena
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Desuscribirse del evento cuando se destruye el objeto
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Chequea si la escena actual es "Tutorial" o "HardMode" y destruye el GameObject si es así
        if (scene.name == "Tutorial" || scene.name == "HardMode")
        {
            Destroy(gameObject);
        }
        // Si quieres asegurarte de que no se destruya en la escena "Forest"
        else if (scene.name == "Forest")
        {
            DontDestroyOnLoad(gameObject); // Asegúrate de que no se destruya
        }
    }

    void Update()
    {
        CheckForKeyPress();
    }

    public void SetVolume(int newVolume)
    {
        volume = Mathf.Clamp(newVolume, 1, 100); // Asegura que el volumen esté entre 1 y 100
        float adjustedVolume = volume / 100f; // Convierte el volumen a un valor entre 0.01 y 1
        if (audioSource != null)
        {
            audioSource.volume = adjustedVolume;
        }
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
