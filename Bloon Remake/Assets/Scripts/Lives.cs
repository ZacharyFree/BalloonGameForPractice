using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour
{
    private string livesUIText;

    public int LivesCounter { get; set; } = 200;
    // Start is called before the first frame update
    void Start()
    {
        livesUIText = LivesCounter.ToString();
        gameObject.GetComponent<Text>().text = livesUIText;
    }

    // Update is called once per frame
    void Update()
    {
        livesUIText = LivesCounter.ToString();
        gameObject.GetComponent<Text>().text = livesUIText;
    }
}
