using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoryScript : MonoBehaviour
{
    private int points;

    private PlayerMovement player;

    GameObject foldy;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private MemoryCard mCard1;
    [SerializeField] private MemoryCard mCard2;
    [SerializeField] private MemoryCard mCard3;
    [SerializeField] private MemoryCard mCard4;
    [SerializeField] private MemoryCard mCard5;
    [SerializeField] private MemoryCard mCard6;
    [SerializeField] private MemoryCard mCard7;
    [SerializeField] private MemoryCard mCard8;
    [SerializeField] private MemoryCard mCard9;
    [SerializeField] private MemoryCard mCard10;

    public Sprite cardTexture1;
    public Sprite cardTexture2;
    public Sprite cardTexture3;
    public Sprite cardTexture4;
    public Sprite cardTexture5;

    public List<MemoryCard> mCards = new List<MemoryCard>();
    public List<int> idNrs = new List<int> { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
    public List<Sprite> textures = new List<Sprite>();

    private bool secondGuess;
    private bool goAgain;

    private MemoryCard guessCard1;
    private MemoryCard guessCard2;

    AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        foldy = GameObject.Find("Foldy");
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        secondGuess = false;
        goAgain = false;

        textures.Add(cardTexture1);
        textures.Add(cardTexture2);
        textures.Add(cardTexture3);
        textures.Add(cardTexture4);
        textures.Add(cardTexture5);

        mCards.Add(mCard1);
        mCards.Add(mCard2);
        mCards.Add(mCard3);
        mCards.Add(mCard4);
        mCards.Add(mCard5);
        mCards.Add(mCard6);
        mCards.Add(mCard7);
        mCards.Add(mCard8);
        mCards.Add(mCard9);
        mCards.Add(mCard10);

        for(int i = 0; i < mCards.Count; i++)
        {
            int tempIndex = Random.Range(0, idNrs.Count);
            mCards[i].idNumber = idNrs[tempIndex];
            idNrs.RemoveAt(tempIndex);
        }

        scoreText.text = "Score: 0";
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Guess(MemoryCard guess)
    {
        if(secondGuess == false)
        {
            if(goAgain == true)
            {
                guessCard1.memImage.enabled = false;
                guessCard2.memImage.enabled = false;
                guessCard1.GetComponentInParent<Button>().enabled = true;
                guessCard2.GetComponentInParent<Button>().enabled = true;
                goAgain = false;
            }
            guessCard1 = null;
            guessCard2 = null;
            guessCard1 = guess;
            secondGuess = true;
        } else
        {
            guessCard2 = guess;

            if(guessCard1.idNumber == guessCard2.idNumber)
            {
                Debug.Log("Thats a match!");
                guessCard1.GetComponentInParent<Button>().enabled = false;
                guessCard2.GetComponentInParent<Button>().enabled = false;
                points++;
                scoreText.text = "Score: " + points;
                audioSource.PlayOneShot(foldy.GetComponent<AudioManager>().coinSound);
                if (points >= 5)
                {
                    Win();
                }
            } else
            {
                Debug.Log("Epic fail!");
                goAgain = true;
                guessCard1.GetComponentInParent<Button>().enabled = false;
                guessCard2.GetComponentInParent<Button>().enabled = false;
            }

            secondGuess = false;
        }

    }

    void Win()
    {
        Destroy(audioSource);
        player.inMinigame = false;
        gameObject.SetActive(false);
    }
}
