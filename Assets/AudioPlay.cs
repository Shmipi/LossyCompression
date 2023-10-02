using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{

    AudioSource audioSource;

    [SerializeField] AudioClip audioClip1;
    [SerializeField] AudioClip audioClip2;
    [SerializeField] AudioClip jump;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playAudio1()
    {
        audioSource.PlayOneShot(audioClip1);
    }


    public void playAudio2()
    {
        audioSource.PlayOneShot(audioClip2);
    }

    public void playAudioJump()
    {
        audioSource.PlayOneShot(jump);
    }

}
