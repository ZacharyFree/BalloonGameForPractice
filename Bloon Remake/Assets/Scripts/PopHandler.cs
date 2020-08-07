using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopHandler : MonoBehaviour
{
    public AudioClip pop;


    public BloonProperties bloonProperties;
    public Collider2D fellowBloons;//used in collision to ignore balloons colliding with themselves

    //COUNT MONEY
    Money money;

    private void Start()
    {
        //PROPERTIES OF BALLOON FROM LEVELS SCRIPT CLASS
        bloonProperties.layers = 1;

        //IGNORE COLLISSIONS WITH OTHER BALLOONS
        //Physics2D.IgnoreCollision(fellowBloons, fellowBloons);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((bloonProperties.poppedBySharp && collision.gameObject.CompareTag("sharp")) || (bloonProperties.poppedByBomb && collision.gameObject.CompareTag("bomb")))
        {
            Debug.Log(name);//I want to know how many trigger collisions are being detected
            bloonProperties.layers--;

        }
    }
    // Update is called once per frame
    void Update()
    {
        Pop();
    }

    void Pop()
    {
        if (bloonProperties.layers <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(pop, transform.position, .5f);
            //money.MoneyCounter++;
        }
    }
}
