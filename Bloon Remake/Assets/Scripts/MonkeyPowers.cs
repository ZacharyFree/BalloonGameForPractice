using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyPowers : MonoBehaviour
{
    //Useful note: OnTriggerStay didn't work with monkey detection collider(as trigger) and balloon collider until balloons had rigidbodies
    public GameObject weapon;
    public GameObject throwpoint;
    private GameObject clonePoint;//use to check children for farthest along balloon; this is the balloon to aim at
    //private PathFollow pathFollow;
    public Collider2D forgetDarts;
    [Tooltip("Default: once every 2 sec")]
    [Range(1, 5)]
    public int attackSpeed = 1;
    public Collider2D range;
    public AudioClip whoosh;
    public int damageLayers = 1;//how many layers each dart affects
    public int damageNumber = 1;//how many ballons a dart pops before it is destroyed
    private int timer = 0;

    int[] allCurrentWayPoints;

    private void Start()
    {
        clonePoint = FindObjectOfType<BloonCloner>().gameObject;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (throwpoint.transform.childCount < 1)//ensures only 1 dart is thrown at a time
        {
            if (timer == 0)//ensures darts are thrown only once every few seconds
            {
                //AimAtBalloon();
                ChuckDartAtBalloon();

                timer++;
            }
            else
            {
                if (timer >= 120 / attackSpeed)
                {
                    timer = 0;
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
        AudioSource.PlayClipAtPoint(whoosh, transform.position);
    }

    void AimAtBalloon()
    {
        allCurrentWayPoints = new int[clonePoint.transform.childCount];
        //find first balloon
        for (int i = 0; i < clonePoint.transform.childCount; i++)
        {

            GameObject bloonBeingInspected = clonePoint.transform.GetChild(i).gameObject;

            allCurrentWayPoints[i] = bloonBeingInspected.GetComponent<PathFollow>().FarthestAlongWaypoint;

            /*if (bloonBeingInspected.GetComponent<PathFollow>().FarthestAlongWaypoint > lastBloonInspected.GetComponent<PathFollow>().FarthestAlongWaypoint)
            {

            }*/
        }

        Vector3 monkeyposition = transform.position;
        if (clonePoint.transform.childCount > 0) 
        {
            GameObject firstBloonOnTrack = clonePoint.transform.GetChild(Mathf.Max(allCurrentWayPoints)).gameObject;
            Vector3 firstBloonPosition = firstBloonOnTrack.transform.position;
            Vector3 offset = monkeyposition - firstBloonPosition;
            float angleToBalloon = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;
            Debug.Log(angleToBalloon);
            if (angleToBalloon > 5f)
            {
                transform.Rotate(0f, 0f, angleToBalloon);
            }
        }

        return;

    }
}