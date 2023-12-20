using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private EnemyData enemyData;
    // enemy infor
    private float hp;
    private int speed;
    private float range;
    private bool isShortType;
    private float shootTimer;
    private int damageEnemy;
    [SerializeField] private GameObject bulletPrefabs;

    private float timer;// 
    private Transform playerTransform;
    private Vector3 directionToPlayer;
    private GameObject enemySpawnBullet;
    //
    [SerializeField] private GameObject[] items;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemySpawnBullet = GameObject.Find("EnemySpawnBullet");
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        speed = enemyData.speed;
        range = enemyData.Range;
        isShortType = enemyData.isShortType;
        shootTimer = enemyData.timeBetweenAttack;
        damageEnemy = enemyData.damage;
        hp = enemyData.hp;
    }


    private void FixedUpdate()
    {
        EnemyMove();
        RotateTowardsPlayer();
        Attack();
        Die();
    }

    public void Attack()
    {


        if (!isShortType)
        {
            if (Vector3.Magnitude(transform.position - playerTransform.position) < range && timer >= shootTimer)
            {
                timer = 0;
                //Vector3 playerPos = playerTransform.position;
                Vector3 direction = directionToPlayer;

                GameObject bulletEnemy = Instantiate(bulletPrefabs, transform.position, transform.rotation);
                bulletEnemy.GetComponent<BulletAttackDirection>().SetDamage(damageEnemy);
                bulletEnemy.GetComponent<BulletAttackDirection>().SetDirection(direction);
                bulletEnemy.transform.SetParent(enemySpawnBullet.transform);

                //max time to destroy bullet
                Destroy(bulletEnemy, 10f);
            }
        }
    }

    public void EnemyMove()
    {
        timer += Time.deltaTime;
        if (!isShortType)
        {
            if (Vector3.Magnitude(transform.position - playerTransform.position) >= range)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            }
            else return;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    // Rotate the enemy towards the player's position
    public void RotateTowardsPlayer()
    {
        directionToPlayer = playerTransform.position - transform.position;
        float dotProduct = Vector3.Dot(directionToPlayer, transform.right); // Calculate dot product

        if (dotProduct > 0)
        {
            // Player is on the right side, flip the sprite to face right
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            // Player is on the left side, flip the sprite to face left
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        animator.SetTrigger("TakeDamage");
    }

    public void Die()
    {
        if (this.hp <= 0)
        {
            animator.SetTrigger("die");
            StartCoroutine(WaitToDie());
        }
    }

    IEnumerator WaitToDie()
    {

        yield return new WaitForSeconds(0.6f);
        int itemIndex = Random.Range(0, 6);
        if (itemIndex != 1)
        {
            Instantiate(items[0], transform.position, Quaternion.identity);
        }
        if (itemIndex == 1)
        {
            Instantiate(items[1], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
            if (player != null)
            {
                animator.SetTrigger("attack");
                player.TakeDamage(damageEnemy);
            }

        }
    }

    public float timeInAoe = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamageAoe"))
        {

            timeInAoe += Time.deltaTime;
            if (timeInAoe > 1)
            {
                timeInAoe = 0;
                TakeDamage(0.5f);
            }

        }
    }

}
