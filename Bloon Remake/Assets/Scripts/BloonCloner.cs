using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonCloner : MonoBehaviour
{
    public LevelCreator levelCreator;//drag in one of numbered 'level' scriptable objects
    public GameObject universalBloon;

    private void Start()
    {
        levelCreator.bloonsSpawnedAlready = 0;
    }

    // Start is called before the first frame update
    void Update()
    {
        levelCreator.ArrangeBloonOrder(gameObject.transform, universalBloon);
    }
}
