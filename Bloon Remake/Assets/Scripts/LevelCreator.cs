using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Level 1", menuName ="New Level")]
public class LevelCreator : ScriptableObject
{
    public ScriptableObject InventoryArray;
    [Range(0f,100f)]
    public int redBalloonsInThisLevel = 10;
    [HideInInspector] public int bloonsSpawnedAlready = 0;
    [Range(0f, 100f)]
    public int blueBalloonsInThisLevel = 10;
    [Range(0f, 100f)]
    public int greenBalloonsInThisLevel = 10;
    [Range(0f, 100f)]
    public int yellowBalloonsInThisLevel = 10;
    [Range(0f, 100f)]
    public int leadBalloonsInThisLevel = 10;
    [HideInInspector] public int timer;//only want access to set at 0 in Start function in BloonCloner


    //Method called from BloonCloner  ============================================================================================
    public void ArrangeBloonOrder(Transform transform, GameObject universalBloon)
    {

        //Red Balloons ================================================================================================
        if (bloonsSpawnedAlready < redBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.red , 1, 500, 0);
        }

        //Blue Balloons ===============================================================================================
        if (bloonsSpawnedAlready < blueBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.blue, 2, 60, 1);
        }

        //Green Balloons ==============================================================================================
        if (bloonsSpawnedAlready < greenBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.green, 3, 60, 2);
        }

        //Yellow Balloons =============================================================================================
        if (bloonsSpawnedAlready < yellowBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.yellow, 4, 60, 3);
        }

        //Lead Balloons =============================================================================================
        if (bloonsSpawnedAlready < leadBalloonsInThisLevel)
        {
            SpawnBalloon(universalBloon, transform, Color.gray, 5, 60, 3);
        }
    }

    //bloonIndex:
    //  0 = red
    //  1 = blue
    //  2 = green    etc.

    public void SpawnBalloon(GameObject universalBloon, Transform transform, Color color, int speed, int framesToWait, int bloonIndex/*should replace color,speed*/)
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
            if (timer >= framesToWait)
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
