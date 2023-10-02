using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCollider : MonoBehaviour
{

    public GameObject miniGame;
    private PlayerMovement player;

    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            miniGame.SetActive(true);
            player.inMinigame = true;
            isColliding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isColliding = false;
        }
    }
}
