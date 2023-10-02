using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip pickupVox;
    public AudioClip pickupSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip moleAppearing;
    public AudioClip moleDisappearing;
    public AudioClip coinSound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
