using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    WhackAMole whackAMole;


    // Start is called before the first frame update
    void OnEnable()
    {
        whackAMole = gameObject.GetComponentInParent<WhackAMole>();
        timeRemaining = Random.Range(0.3f, 0.5f);
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                whackAMole.LosePoint();
                timeRemaining = 0;
                timerIsRunning = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void WackMole()
    {
        Debug.Log("You Wacked the mole!");
        whackAMole.GainPoints();
        timeRemaining = 0;
        timerIsRunning = false;
        gameObject.SetActive(false);
    }
}
