using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level 1", menuName ="New Level")]
public class LevelCreator : ScriptableObject
{
    public GameObject universalBloon;
    [Range(10f,100f)]
    public int redBalloonsInThisLevel = 10;
    [HideInInspector] public int bloonsSpawnedAlready = 0;
    [Range(10f, 100f)]
    public int blueBalloonsInThisLevel = 10;
    [Range(10f, 100f)]
    public int greenBalloonsInThisLevel = 10;
    [Range(10f, 100f)]
    public int yellowBalloonsInThisLevel = 10;

    public void ArrangeBloonOrder(Transform transform, GameObject universalBloon)
    {

        //Red Balloons ================================================================================================
        if (bloonsSpawnedAlready < redBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.red , 1, 60, 0);
        }

        //Blue Balloons ===============================================================================================
        if (bloonsSpawnedAlready < blueBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.blue, 2, 60, 0);
        }

        //Green Balloons ==============================================================================================
        if (bloonsSpawnedAlready < greenBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.green, 3, 60, 0);
        }

        //Yellow Balloons =============================================================================================
        if (bloonsSpawnedAlready < greenBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.yellow, 4, 60, 0);
        }
    }
public void SpawnBalloon(GameObject universalBloon, Transform transform, Color color, int speed, int framesToWait, int timer)
    {
        if (timer == 0)
        {
            GameObject newBloon = Instantiate(universalBloon, transform);
            newBloon.GetComponentInChildren<SpriteRenderer>().color = color;
            newBloon.GetComponent<PathFollow>().speed = speed;
            bloonsSpawnedAlready++;

            timer++;
        }
        else
        {
            if (timer == framesToWait)
            {
                timer = 0;
            }
            else
            {
                //Debug.Log("Timer is at " + timer);
                timer++;
            }
        }
    }
}
