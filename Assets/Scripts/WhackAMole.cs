using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WhackAMole : MonoBehaviour
{
    [SerializeField] private GameObject mole1;
    [SerializeField] private GameObject mole2;
    [SerializeField] private GameObject mole3;
    [SerializeField] private GameObject mole4;
    [SerializeField] private GameObject mole5;
    [SerializeField] private GameObject mole6;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int points;

    public List<GameObject> moles = new List<GameObject>();

    public float timeRemaining = 0.5f;
    public bool timerIsRunning = false;

    private PlayerMovement player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        scoreText.text = "Score: 0";

        moles.Add(mole1);
        moles.Add(mole2);
        moles.Add(mole3);
        moles.Add(mole4);
        moles.Add(mole5);
        moles.Add(mole6);

        for (int i = 0; i < moles.Count; i++)
        {
            moles[i].SetActive(false);
        }

        points = 0;

        timerIsRunning = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Bing bong");
                GameObject tempMole = moles[Random.Range(0, moles.Count)];
                if(tempMole.activeInHierarchy != true)
                {
                    tempMole.SetActive(true);
                    timeRemaining = Random.Range(1, 3);
                }
            }
        }
        
    }

    public void GainPoints()
    {
        points += 2;
        scoreText.text = "Score: " + points;

        if(points >= 10)
        {
            Win();
        }
    }

    public void LosePoint()
    {
        points--;
        if (points < 0)
        {
            points = 0;
        }
        scoreText.text = "Score: " + points;
    }

    public void Win()
    {
        player.inMinigame = false;
        gameObject.SetActive(false);
    }
}
