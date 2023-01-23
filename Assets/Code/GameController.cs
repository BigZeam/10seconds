using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPlaying, win, lose, restarting;
    public Text timerText;
    public GameObject winObj, loseObj, toolTip, playerObj, titleObj;
    float timer;
    void Start()
    {
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            titleObj.SetActive(false);
            StartCoroutine(GameSetUp());
        }
        if(isPlaying)
        {
            restarting = false;
            timer-= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2");

            if(timer <=0)
            {
                timer = 0;
                isPlaying = false;
                win = true;
                Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
            }
        }
        if(lose)
        {
            loseObj.SetActive(true);
        }
        if(win)
        {
            winObj.SetActive(true);
        }
    }

    public void Dead()
    {
        isPlaying = false;
        lose = true;
    }
    public bool GetState()
    {
        return isPlaying;
    }

    IEnumerator GameSetUp()
    {
        if(restarting == false)
        {
            restarting = true;
            if(GameObject.FindGameObjectWithTag("Player") != null)
            Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
        
        if(GameObject.FindGameObjectsWithTag("Enemy") != null)
        {
            GameObject[] misery = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in misery)
            {
                Destroy(enemy.gameObject);
            }
        }
        toolTip.SetActive(true);
        isPlaying = false;
        win = false;
        lose = false;
        timer = 0;
        winObj.SetActive(false);
        loseObj.SetActive(false);
        yield return new WaitForSeconds(2f);
        toolTip.SetActive(false);
        isPlaying = true;
        timer = 10;
        Instantiate(playerObj, transform.position, Quaternion.identity);
        }
        
        
    }
    
}
