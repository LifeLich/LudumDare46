using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static void PlayerClip(AudioClip audioClip, Vector3 position)
    {
        audioSource.Stop();
        audioSource.transform.position = position;
        audioSource.clip = audioClip;
        audioSource.Play();

    }
    static AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
