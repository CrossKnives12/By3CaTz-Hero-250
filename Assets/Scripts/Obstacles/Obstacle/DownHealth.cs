using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownHealth : MonoBehaviour
{
    public int health;
    public bool triggerDeath;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        triggerDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            triggerDeath = true;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
