using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int totalDmgStacksOverall;
    public int totalStageFinished;

    public int getDmgBonusFromEnemies;
    public int getDmgBonusFromBosses;

    public int getStageValueFromEnemies;
    public int getStageValueFromBosses;

    public GameObject enemy;
    private EnemyHealth eh;

    public GameObject bossManager;
    private BossManager bm;

    public bool activateEndText;

    public GameObject openEndText;
    public bool destroyAllObjects;

    public GameObject missileUp;
    public GameObject missileDown;
    public GameObject missileLeft;
    public GameObject missileRight;

    private UpMissile um;
    private DownMissile dm;
    private LeftMissile lm;
    private RightMissile rm;

    // Start is called before the first frame update
    void Start()
    {
        eh = enemy.GetComponent<EnemyHealth>();
        bm = bossManager.GetComponent<BossManager>();

        um = missileUp.GetComponent<UpMissile>();
        dm = missileDown.GetComponent<DownMissile>();
        lm = missileLeft.GetComponent<LeftMissile>();
        rm = missileRight.GetComponent<RightMissile>();

        getDmgBonusFromEnemies = 0;
        getDmgBonusFromBosses = 0;

        getStageValueFromEnemies = 0;
        getStageValueFromBosses = 0;

        activateEndText = false;
        destroyAllObjects = false;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDmgBonus();
        CalculateStageValue();

        ShowEndText();
    }

    void CalculateDmgBonus()
    {
        getDmgBonusFromEnemies = eh.tempDmgStacks;
        getDmgBonusFromBosses = bm.tempDmgBossStacks;

        totalDmgStacksOverall = getDmgBonusFromEnemies + getDmgBonusFromBosses;
    }

    void CalculateStageValue()
    {
        getStageValueFromEnemies = eh.tempStageValue;
        getStageValueFromBosses = bm.tempStageBossStacks;

        totalStageFinished = getStageValueFromEnemies + getStageValueFromBosses;
    }

    void ShowEndText()
    {
        if (activateEndText == true)
        {
            destroyAllObjects = true;
            um.selfDestructUp = true;
            dm.selfDestructDown = true;
            lm.selfDestructLeft = true;
            rm.selfDestructRight = true;

            openEndText.SetActive(true);
        }
    }
}
