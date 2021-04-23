using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int tempDmgBossStacks;
    public int tempStageBossStacks;

    public AudioSource explodeSource;
    public bool triggerSFX;

    public GameObject ringEffect;

    // Start is called before the first frame update
    void Start()
    {
        explodeSource = GetComponent<AudioSource>();
        triggerSFX = false;

        tempDmgBossStacks = 0;
        tempStageBossStacks = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //add ring effect and sounds
        if (triggerSFX == true)
        {
            //explodeSource.Play();
            ringEffect.SetActive(true);

            triggerSFX = false;
        }
    }
}
