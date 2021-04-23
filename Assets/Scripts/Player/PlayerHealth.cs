using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject deathPlayerEffect;

    public bool playerHasDied;

    // Start is called before the first frame update
    void Start()
    {
        playerHasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        HeartContainers();
        PlayerDeath();
    }

    void HeartContainers()
    {
        health = numOfHearts;

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void PlayerDeath()
    {
        if (health == 0)
        {
            playerHasDied = true;

            Instantiate(deathPlayerEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
