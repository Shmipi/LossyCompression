using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{

    AudioSource audioSource;

    [SerializeField] AudioClip[] driveClips;

    [SerializeField] AudioClip[] foldyClips;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void playDrive()
    {
        AudioClip driveClip = driveClips[UnityEngine.Random.Range(0, driveClips.Length)];
        audioSource.PlayOneShot(driveClip);
    }

    void playFoldy()
    {
        AudioClip foldyClip = driveClips[UnityEngine.Random.Range(0, foldyClips.Length)];
        audioSource.PlayOneShot(foldyClip);
    }

}
