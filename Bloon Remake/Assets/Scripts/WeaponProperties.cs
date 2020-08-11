using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProperties : MonoBehaviour
{
    public Collider2D monkeyDetectionCollider;
    public Collider2D dartCollider;
    public Rigidbody2D dartBody;
    public float dartSpeed = 1f;
    private int lifeTimer;
    public int layersAllowedToPop = 1;
    // Start is called before the first frame update

    private void Awake()
    {
        lifeTimer = 0;

    }
    void Start()
    {
        dartBody.velocity = transform.up * dartSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        //lifetime length check
        lifeTimer++;
        if (lifeTimer > 120 || layersAllowedToPop <= 0)//if dart is over 2 seconds old or has popped all balloons it can, destroy it
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bloon"))
        {
            layersAllowedToPop--;
        }
    }
}
