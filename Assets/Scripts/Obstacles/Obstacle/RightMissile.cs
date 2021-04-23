using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMissile : MonoBehaviour
{
    public GameObject deathEffect;

    [SerializeField] private int damage;
    public float speed;
    public int lifeTime;

    public bool selfDestructRight;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        Invoke("DestroyObject", lifeTime);
        selfDestructRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (selfDestructRight == true)
        {
            DestroyObject();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().numOfHearts -= damage;

            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
