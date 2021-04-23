using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMissile : MonoBehaviour
{
    public GameObject deathEffect;

    [SerializeField] private int damage;
    public float speed;
    public int lifeTime;

    public GameObject childHealthDown;
    private DownHealth dh;

    public bool selfDestructDown;

    // Start is called before the first frame update
    void Start()
    {
        dh = childHealthDown.GetComponent<DownHealth>();

        damage = 1;
        Invoke("DestroyObject", lifeTime);
        selfDestructDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (dh.triggerDeath == true)
        {
            DestroyObject();
        }

        if (selfDestructDown == true)
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
