using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public int newDmgStacksReceived;
    public int newStageValueReceived;
    public int highestStageOverall;

    public int incrementDMG = 0;

    public TMP_Text dmgText;

    // Start is called before the first frame update
    void Start()
    {
        //amount of dmg bonus stacks received from previous run
        newDmgStacksReceived = PlayerPrefs.GetInt("dmgStacks");

        //the farthest stage reached from the previous run
        newStageValueReceived = PlayerPrefs.GetInt("stage");

        //data that will be carried over between scenes
        highestStageOverall = PlayerPrefs.GetInt("highStage");
    }

    // Update is called once per frame
    void Update()
    {
        ValueChecker();
        DmgTracker();
    }

    void ValueChecker()
    {
        if (newStageValueReceived > 0)
        {
            //currentStage >= highestStage
            if (newStageValueReceived >= highestStageOverall)
            {
                highestStageOverall = newStageValueReceived;
                incrementDMG = newDmgStacksReceived;

                PlayerPrefs.SetInt("storeNewHighStageValue", highestStageOverall);
                PlayerPrefs.SetInt("newAddedDmg", incrementDMG);
            }
        }
    }

    void DmgTracker()
    {
        dmgText.text = "You have received " + incrementDMG + " bonus damage";
    }
}
