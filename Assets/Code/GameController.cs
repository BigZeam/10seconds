using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPlaying, win, lose;
    Text timerText;
    float timer;
    void Start()
    {
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            timer-= Time.deltaTime;
            timerText.text = "Time: " + timer;
        }
    }
}
