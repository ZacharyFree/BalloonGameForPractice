using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    public ScriptableObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        //Start level one, and change start button to say "pause" and function to pause game
    }

    // Update is called once per frame
    void Update()
    {
        //check if all bloons have been spawned and are dead.
        //if so, change button to say "Next Level"
        //when button is pressed, load next level (which is a scriptable object in our public array)
        //and begin the instantiating of bloons in that level

        //repeat this process as many times as there are levels in our array
    }
}
