using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMissile : MonoBehaviour
{
    public GameObject deathEffect;

    [SerializeField] private int damage;
    public float speed;
    public int lifeTime;

    public GameObject childHealth;
    private UpHealth uh;

    public bool selfDestructUp;

    // Start is called before the first frame update
    void Start()
    {
        uh = childHealth.GetComponent<UpHealth>();

        damage = 1;
        Invoke("DestroyObject", lifeTime);
        selfDestructUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (uh.triggerDeath == true)
        {
            DestroyObject();
        }

        if (selfDestructUp == true)
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
