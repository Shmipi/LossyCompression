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

    AudioSource audioSource;

    GameObject PlayerObject;

    private int points;

    public List<GameObject> moles = new List<GameObject>();

    public float timeRemaining = 0.5f;
    public bool timerIsRunning = false;

    private PlayerMovement player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        PlayerObject = GameObject.Find("Foldy");
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
        audioSource.Play();
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
                    PlayerObject.GetComponent<AudioSource>().PlayOneShot(PlayerObject.GetComponent<AudioManager>().moleAppearing);
                    timeRemaining = Random.Range(1, 3);
                }
            }
        }
        
    }

    public void GainPoints()
    {
        points += 2;
        scoreText.text = "Score: " + points;
        PlayerObject.GetComponent<AudioSource>().PlayOneShot(PlayerObject.GetComponent<AudioManager>().coinSound);

        if (points >= 10)
        {
            Win();
        }
    }

    public void LosePoint()
    {
        points--;
        PlayerObject.GetComponent<AudioSource>().PlayOneShot(PlayerObject.GetComponent<AudioManager>().moleDisappearing);
        if (points < 0)
        {
            points = 0;
            PlayerObject.GetComponent<AudioSource>().PlayOneShot(PlayerObject.GetComponent<AudioManager>().loseSound);
        }
        scoreText.text = "Score: " + points;
    }

    public void Win()
    {
        PlayerObject.GetComponent<AudioSource>().PlayOneShot(PlayerObject.GetComponent<AudioManager>().winSound);
        player.inMinigame = false;
        gameObject.SetActive(false);
    }
}
