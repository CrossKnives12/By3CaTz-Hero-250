using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyLifeforce;
    private EnemyHealth eh;

    public GameObject player;
    private PlayerHealth ph;

    public GameObject playerProjectile;
    private PlayerBullet pb;

    public GameObject sceneManager;
    private SceneLoader sl;

    public GameObject stageManager;
    private StageManager sm;

    //playerprefs these variable
    public int receivedDmgStacks;
    public int currentStage;
    public int highestStage;

    public int incrementDmgTrigger;

    public bool waitTimeBeforeStatsScene;
    [SerializeField] private float waitTimer;
    [SerializeField] private float waitTimerMax;

    // Start is called before the first frame update
    void Start()
    {
        eh = enemyLifeforce.GetComponent<EnemyHealth>();
        ph = player.GetComponent<PlayerHealth>();
        pb = playerProjectile.GetComponent<PlayerBullet>();
        sl = sceneManager.GetComponent<SceneLoader>();
        sm = stageManager.GetComponent<StageManager>();

        waitTimeBeforeStatsScene = false;
        waitTimerMax = 3;
        waitTimer = waitTimerMax;

        receivedDmgStacks = 0;
        currentStage = eh.tempStageValue;

        //playerprefs to save highest stage value, equal to highestStage variable
        highestStage = PlayerPrefs.GetInt("storeNewHighStageValue");
    }

    // Update is called once per frame
    void Update()
    {
        GetTempDmgStacks();

        currentStage = sm.totalStageFinished;

        if (ph.playerHasDied == true)
        {
            waitTimeBeforeStatsScene = true;
        }

        if (waitTimeBeforeStatsScene == true)
        {
            waitTimer -= 1 * Time.deltaTime;
        }

        if (waitTimer <= 0)
        {
            incrementDmgTrigger = 1;
            SetPlayerPrefs();
        }
    }

    void GetTempDmgStacks()
    {
        receivedDmgStacks = sm.totalDmgStacksOverall;
    }

    void SetPlayerPrefs()
    {
        PlayerPrefs.SetInt("stage", currentStage);
        PlayerPrefs.SetInt("dmgStacks", receivedDmgStacks);
        PlayerPrefs.SetInt("highStage", highestStage);
        PlayerPrefs.SetInt("DmgTrigger", incrementDmgTrigger);

        sl.activateStatsScene = true;
    }
}
