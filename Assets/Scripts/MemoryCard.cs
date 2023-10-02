using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    public int idNumber;
    public Image memImage;
    private MemoryScript memory;

    // Start is called before the first frame update
    void Start()
    {
        DisableImage();

        memory = gameObject.GetComponentInParent<MemoryScript>();

        memImage.sprite = memory.textures[idNumber - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickCard()
    {
        Debug.Log("This is my ID" + idNumber);
        memImage.enabled = true;
        memory.Guess(gameObject.GetComponent<MemoryCard>());
    }

    public void DisableImage()
    {
        memImage.enabled = false;
    }
}
