using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    GameController gc;
    public float xspeed, yspeed;
    public bool active;
    float timer;
    public GameObject enemyPrefab, partPrefab;
    public Transform[] positions;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        timer = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime*1;
        if(gc.GetState() && timer <= 0)
        {
            GameObject enemy = Instantiate(enemyPrefab, positions[Random.Range(0, positions.Length)].position, Quaternion.identity);
            enemy.GetComponent<EnemyController>().SetSpeed(xspeed, yspeed);
            timer = Random.Range(1, 3);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy")
            Destroy(other.gameObject);
    }
}
