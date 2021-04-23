using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSpawner : MonoBehaviour
{
    public GameObject obstacleUpSpawn;

    public GameObject stageManager;
    private StageManager sm;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    private float randX;
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
            if (sm.totalStageFinished >= 51)
            {
                if (timeBtwSpawn <= 0)
                {
                    randX = Random.Range(-5.00f, 6.00f); //the range where enemy spawns
                    whereToSpawn = new Vector2(randX, transform.position.y); //the position where it spawns
                    Instantiate(obstacleUpSpawn, whereToSpawn, Quaternion.identity);

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
