using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float xspeed, yspeed;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(xspeed * Time.deltaTime, yspeed * Time.deltaTime, 0);
        if(transform.position.magnitude > 15)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetSpeed(float x, float y)
    {
        xspeed = x;
        yspeed = y;
    }
}
