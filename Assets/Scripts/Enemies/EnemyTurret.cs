using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer),typeof(Rigidbody2D))]
public class EnemyTurret : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;


    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Projectile enemyProjectilePrefab;

    public float projectileForce;

    public float projectileFireRate;
    public float turretFireDistance;
    float timeSinceLastFire = 0.0f;
    bool canFire;
    public int health;

    GameObject player;

  
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        


        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

        if (projectileFireRate <= 0)
        {
            projectileFireRate = 2.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (player)
        {   
            if (player.transform.position.x < transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }

            float distance = Vector2.Distance(transform.position, player.transform.position);
           
            if (distance <= turretFireDistance)
            {
                canFire = true;
            }
            else
            {
                canFire = false;
            }

            //HINT 1 FOR LAB: CHECK SOMETHING PRIOR TO FIRING TO DETERMING WHICH DIRECTION TO FIRE - CAN ALSO INCLUDE DISTANCE
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {
                if (canFire)
                {
                    anim.SetBool("Fire", true);
                    timeSinceLastFire = Time.time;
                }

            }
        }
        else
        {
           if (GameManager.instance.playerInstance)
              player = GameManager.instance.playerInstance;
        }

    }

    public void Fire()
    {
        //HINT 2 FOR LAB: IF YOU KNOW THE DIRECTION - YOU CAN ADD LOGIC HERE TO FIRE IN THAT DIRECTION
       
        if (sr.flipX)
        {
          Projectile temp = Instantiate(enemyProjectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
          temp.speed = -projectileForce;
        }
        else
        {
            Projectile temp = Instantiate(enemyProjectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            temp.speed = projectileForce;
        }
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}