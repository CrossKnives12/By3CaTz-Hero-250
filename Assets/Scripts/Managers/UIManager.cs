using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text stageText;

    public GameObject gameManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;

        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StageTracker();
    }

    void StageTracker()
    {
        stageText.text = gm.currentStage + "/250";
    }


}
