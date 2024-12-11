using UnityEngine;

//Plays random sound effects at intervals.

public class PlaySound : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip[] soundEffects;    //Array of sound effects
    public float minTimeBetweenSounds = 1f;
    public float maxTimeBetweenSounds = 5f;

    private AudioSource audioSource;   //Reference to AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (soundEffects.Length > 0 && audioSource != null)
        {
            PlayRandomSound();
        }
        else
        {
            Debug.LogWarning("No AudioClips or AudioSource is missing.");
        }
    }

    void PlayRandomSound()
    {
        if (soundEffects.Length > 0)
        {
            audioSource.clip = soundEffects[Random.Range(0, soundEffects.Length)];
            audioSource.Play();

            Invoke("PlayRandomSound", audioSource.clip.length + Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds));
        }
    }
}
