using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{  
    public GameObject deathEffect;
    public int tempStageValue;
    public int tempDmgStacks;
    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        tempStageValue = 0;
        tempDmgStacks = 0;
        maxHealth = 10;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDeath();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void EnemyDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            tempStageValue += 1; //pass to stage manager
            tempDmgStacks += 2; //pass to stage manager
            maxHealth += 10;
            currentHealth = maxHealth;          
        }
    }
}
