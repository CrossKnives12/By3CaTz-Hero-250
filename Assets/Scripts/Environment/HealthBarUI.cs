using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider lifeSlider;

    public GameObject getEnemyHealth;
    private EnemyHealth eh;

    public GameObject stageManager;
    private StageManager sm;

    //---------------------------------------------
    public GameObject bossOne;
    private BossHealth bo;

    public GameObject bossTwo;
    private BossHealth bt;

    public GameObject bossThree;
    private BossHealth bth;

    public GameObject bossFour;
    private BossHealth bf;

    public GameObject bossFive;
    private BossHealth bfi;


    // Start is called before the first frame update
    void Start()
    {
        eh = getEnemyHealth.GetComponent<EnemyHealth>();
        sm = stageManager.GetComponent<StageManager>();

        bo = bossOne.GetComponent<BossHealth>();
        bt = bossTwo.GetComponent<BossHealth>();
        bth = bossThree.GetComponent<BossHealth>();
        bf = bossFour.GetComponent<BossHealth>();
        bfi = bossFive.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sm.totalStageFinished == 250) //250
        {
            lifeSlider.maxValue = bfi.maxBossHealth;
            lifeSlider.value = bfi.currentBossHealth;
        }
        else if (sm.totalStageFinished == 200) //200
        {
            lifeSlider.maxValue = bf.maxBossHealth;
            lifeSlider.value = bf.currentBossHealth;
        }
        else if (sm.totalStageFinished == 150) //150
        {
            lifeSlider.maxValue = bth.maxBossHealth;
            lifeSlider.value = bth.currentBossHealth;
        }
        else if (sm.totalStageFinished == 100) //100
        {
            lifeSlider.maxValue = bt.maxBossHealth;
            lifeSlider.value = bt.currentBossHealth;
        }
        else if (sm.totalStageFinished == 50) //50
        {
            lifeSlider.maxValue = bo.maxBossHealth;
            lifeSlider.value = bo.currentBossHealth;
        }
        else
        {
            lifeSlider.maxValue = eh.maxHealth;
            lifeSlider.value = eh.currentHealth;
        }
    }
}
