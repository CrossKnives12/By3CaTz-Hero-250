using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    private EnemyHealth eh;

    public GameObject stageManager;
    private StageManager sm;

    public GameObject[] summonedEntities;

    public bool spawnNext;
    

    // Start is called before the first frame update
    void Start()
    {
        eh = enemy.GetComponent<EnemyHealth>();
        sm = stageManager.GetComponent<StageManager>();
        spawnNext = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sm.destroyAllObjects == false)
        {
            SpawnNextEnemy();
        }
        
    }

    void SpawnNextEnemy()
    {
        if (sm.totalStageFinished == 250) //250
        {
            summonedEntities[5].SetActive(true);
            //--------------------------------------------
            summonedEntities[0].SetActive(false);
        }

        else if (sm.totalStageFinished == 200) //200
        {
            summonedEntities[4].SetActive(true);
            //--------------------------------------------
            summonedEntities[0].SetActive(false);
        }

        else if (sm.totalStageFinished == 150) //150
        {
            summonedEntities[3].SetActive(true);
            //--------------------------------------------
            summonedEntities[0].SetActive(false);
        }

        else if (sm.totalStageFinished == 100) //100
        {
            summonedEntities[2].SetActive(true);
            //--------------------------------------------
            summonedEntities[0].SetActive(false);
        }

        else if (sm.totalStageFinished == 50) //50
        {
            summonedEntities[1].SetActive(true);
            //--------------------------------------------
            summonedEntities[0].SetActive(false);
        }

        else
        {
            summonedEntities[0].SetActive(true);
            //--------------------------------------------
            summonedEntities[1].SetActive(false);
            summonedEntities[2].SetActive(false);
            summonedEntities[3].SetActive(false);
            summonedEntities[4].SetActive(false);
            summonedEntities[5].SetActive(false);
        }
    }
}
