using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCol : MonoBehaviour
{
    [SerializeField] private int damage;
    
    public float speed;
    public GameObject deathEffect;
    public int lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;

        Invoke("DestroyObject", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().numOfHearts -= damage;

            DestroyObject();
        }      
        else if (other.CompareTag("Bullet"))
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
