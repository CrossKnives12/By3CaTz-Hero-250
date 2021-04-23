using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSpawner : MonoBehaviour
{
    public GameObject obstacleLeftSpawn;

    public GameObject stageManager;
    private StageManager sm;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    private float randY;
    private Vector2 whereToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        sm = stageManager.GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sm.destroyAllObjects == false)
        {
            if (sm.totalStageFinished >= 101)
            {
                if (timeBtwSpawn <= 0)
                {
                    randY = Random.Range(4.00f, -2.50f); //the range where enemy spawns
                    whereToSpawn = new Vector2(transform.position.x, randY); //the position where it spawns
                    Instantiate(obstacleLeftSpawn, whereToSpawn, Quaternion.identity);

                    timeBtwSpawn = startTimeBtwSpawn;
                }
                else
                {
                    timeBtwSpawn -= Time.deltaTime;
                }
            }
        }

        
    }
}
