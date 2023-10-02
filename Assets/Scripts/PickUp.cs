using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float initialPosition;
    private float newPosition;
    public float offset = 9;
    
    
    void Start()
    {
        initialPosition = transform.position.y;
        newPosition = initialPosition + offset;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.CompareTag("Player");

        Debug.Log("wow a pickUp!");

        Destroy(gameObject);
    }
}
