using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingScript : MonoBehaviour
{

    AudioSource audioSource;

    [SerializeField] AudioClip[] driveClips = new AudioClip[5];

    [SerializeField] AudioClip[] foldyClips = new AudioClip[5];

    GameObject foldy;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foldy = GameObject.Find("Foldy");

    }


    public void playDrive()
    {
        AudioClip driveClip = driveClips[Random.Range(0, 5)];
        audioSource.PlayOneShot(driveClip);
    }

    public void playFoldy()
    {
        AudioClip foldyClip = foldyClips[Random.Range(0, 5)];
        audioSource.PlayOneShot(foldyClip);
    }


}
