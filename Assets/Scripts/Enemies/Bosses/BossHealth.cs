using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject deathEffect;
    public int tempStageValueFromBoss;
    public int tempDmgStacksFromBoss;
    public int maxBossHealth;
    public int currentBossHealth;

    public GameObject bossManager;
    private BossManager bm;

    public GameObject stageManager;
    private StageManager sm;

    public GameObject playerLife;
    private PlayerHealth ph;


    // Start is called before the first frame update
    void Start()
    {
        bm = bossManager.GetComponent<BossManager>();
        sm = stageManager.GetComponent<StageManager>();
        ph = playerLife.GetComponent<PlayerHealth>();

        tempStageValueFromBoss = 0;
        tempDmgStacksFromBoss = 0;
        maxBossHealth = 100; //change starting life to 3125
        currentBossHealth = maxBossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDeath();
    }

    public void TakeDamage(int damage)
    {
        currentBossHealth -= damage;
    }

    void EnemyDeath()
    {
        if (currentBossHealth <= 0)
        {
            bm.triggerSFX = true;

            if (sm.totalStageFinished == 250)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                sm.activateEndText = true;
            }
            else if (sm.totalStageFinished == 200)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                ph.numOfHearts += 1;
                bm.tempDmgBossStacks += 2;
                bm.tempStageBossStacks += 1;
                maxBossHealth = 50000;
                currentBossHealth = maxBossHealth;
            }
            else if (sm.totalStageFinished == 150)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                ph.numOfHearts += 1;
                bm.tempDmgBossStacks += 2;
                bm.tempStageBossStacks += 1;
                maxBossHealth = 25000;
                currentBossHealth = maxBossHealth;
            }
            else if (sm.totalStageFinished == 100)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                ph.numOfHearts += 1;
                bm.tempDmgBossStacks += 2;
                bm.tempStageBossStacks += 1;
                maxBossHealth = 12500;
                currentBossHealth = maxBossHealth;
            }
            if (sm.totalStageFinished == 50) //50
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                ph.numOfHearts += 1;
                bm.tempDmgBossStacks += 2;
                bm.tempStageBossStacks += 1;
                maxBossHealth = 6250;
                currentBossHealth = maxBossHealth;
            }
            
        }
    }


}
