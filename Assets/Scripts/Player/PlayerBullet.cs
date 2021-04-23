using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float distance;

    public int reviveDamageBonus;

    public int damage;

    public LayerMask whatisSolid;
    public GameObject destroyEffect;

    public int incrementDmgStatic;
    public int addDmgStacks;

    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        Invoke("DestroyBullet", lifeTime);

        //calls the incrementDmgTrigger again
        incrementDmgStatic = PlayerPrefs.GetInt("DmgTrigger");

        //playerprefs to add stacks to damage
        addDmgStacks = PlayerPrefs.GetInt("newAddedDmg");
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();

        if (incrementDmgStatic == 1)
        {
            damage = addDmgStacks;
        }
    }

    void BulletMovement()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatisSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<BossHealth>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Shootable"))
            {
                hitInfo.collider.GetComponent<UpHealth>().TakeDamage(damage);
            }
            else if (hitInfo.collider.CompareTag("Killable"))
            {
                hitInfo.collider.GetComponent<DownHealth>().TakeDamage(damage);
            }

            DestroyBullet();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
