using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMissile : MonoBehaviour
{
    public GameObject deathEffect;
    public float speed;
    public int lifeTime;

    public bool selfDestructLeft;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", lifeTime);
        selfDestructLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (selfDestructLeft == true)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
