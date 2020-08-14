using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopHandler : MonoBehaviour
{
    public AudioClip pop;


    public BloonProperties bloonProperties;
    private int thisBloonsLayers;
    //COUNT MONEY
    private GameObject moneyText;

    private void Start()
    {
        moneyText = FindObjectOfType<Money>().gameObject;
        thisBloonsLayers = bloonProperties.layers;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bloonProperties.poppedBySharp && collision.gameObject.CompareTag("sharp")) || (bloonProperties.poppedByBomb && collision.gameObject.CompareTag("bomb")))
        {
            thisBloonsLayers--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Pop();
    }

    void Pop()
    {
        if (thisBloonsLayers <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(pop, transform.position, .5f);
            moneyText.GetComponent<Money>().MoneyCounter++;
        }
    }
}
