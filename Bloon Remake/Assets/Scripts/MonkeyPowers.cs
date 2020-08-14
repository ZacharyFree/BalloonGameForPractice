using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MonkeyPowers : MonoBehaviour
{
    //Useful note: OnTriggerStay didn't work with monkey detection collider(as trigger) and balloon collider until balloons had rigidbodies
    public GameObject weapon;
    public GameObject throwpoint;
    public Collider2D forgetDarts;
    [Tooltip("Default: once every 2 sec")]
    [Range(1,5)]
    public int attackSpeed = 1;
    public Collider2D range;
    public AudioClip whoosh;
    public int damageLayers = 1;//how many layers each dart affects
    public int damageNumber = 1;//how many ballons a dart pops before it is destroyed
    private int timer = 0;


    private void OnTriggerStay2D(Collider2D collision)
    {
        //Physics2D.IgnoreCollision(forgetDarts,range);//don't let monkey see darts
        if (throwpoint.transform.childCount < 1)
        {
            if (timer == 0)
            {
                ChuckDartAtBalloon();
                UnityEngine.Debug.Log("Timer is at " + timer);

                timer++;
            }
            else
            {
                if (timer == 60 * attackSpeed)
                {
                    timer = 0;
                    UnityEngine.Debug.Log("");
                }
                else
                {
                    timer++;
                }

            }
        }
    }

    void ChuckDartAtBalloon()
    {
        Instantiate(weapon, throwpoint.transform);
        AudioSource.PlayClipAtPoint(whoosh,transform.position);
    }
}
