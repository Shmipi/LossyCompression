using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhackAMole : MonoBehaviour
{
    [SerializeField] private Button mole1;
    [SerializeField] private Button mole2;
    [SerializeField] private Button mole3;
    [SerializeField] private Button mole4;
    [SerializeField] private Button mole5;
    [SerializeField] private Button mole6;

    private int points;

    public Button[] moles;

    public float timeRemaining = 5;

    // Start is called before the first frame update
    void Awake()
    {
        moles = new Button[] {mole1, mole2, mole3, mole4, mole5, mole6};

        for(int i = 0; i < moles.Length; i++)
        {
            moles[i].enabled = false;
        }

        points = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            Debug.Log("Time has run out!");
        }
        
    }
}
