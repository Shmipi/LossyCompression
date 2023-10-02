using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //public float minimum = -0.5f;
    //public float maximum = 0.5f;
    //static float t = 0.0f;

    public float amp;
    public float freq;

    Vector3 initialPosition;

    GameObject Player;
    GameObject AudioManager;

    AudioSource audioSource;
        
    void Start()
    {
        initialPosition = transform.position;
        Player = GameObject.Find("Foldy");
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        /*
        transform.position = new Vector3 (transform.position.x, Mathf.Lerp(t, minimum, maximum), 0);

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
        */

                transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * freq) * amp + initialPosition.y, 0);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        collision.gameObject.CompareTag("Player");

        Debug.Log("wow a pickUp!");

      //  Player.GetComponent<AudioSource>().PlayOneShot(Player.GetComponent<AudioManager>().pickupSound);
        Player.GetComponent<TalkingScript>().playFoldy();


        Destroy(gameObject);
    }
}
