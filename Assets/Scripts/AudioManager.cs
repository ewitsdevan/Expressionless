using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip tone;
    public AudioClip woosh;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void Tone()
    {
        sfxSource.clip = tone;
        sfxSource.pitch = Random.Range(0.5f, 1);
        sfxSource.Play();
    }

    public void Woosh()
    {
        sfxSource.clip = woosh;
        sfxSource.pitch = 1;
        sfxSource.Play();
    }

    public void StopMusic()
    {
        StartCoroutine(MusicFadeOut());
    }

    IEnumerator MusicFadeOut()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 1.0f)
        {
            musicSource.volume = Mathf.Lerp(1, 0, t);

            yield return null;
        }
    }

    public void correctTone()
    {
        sfxSource.clip = tone;
        sfxSource.pitch = 1f;
        sfxSource.Play();
    }

    public void wrongTone()
    {
        sfxSource.clip = tone;
        sfxSource.pitch = 0.5f;
        sfxSource.Play();
    }
}
