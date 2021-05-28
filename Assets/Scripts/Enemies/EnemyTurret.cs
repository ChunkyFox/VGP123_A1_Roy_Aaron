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
    public Projectile projectilePrefab;

    public float projectileForce;

    public float projectileFireRate;

    float timeSinceLastFire = 0.0f;
    public int health;

    public float range;
    public Transform target;
    //bool Detected = false;



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
        this.sr.flipX = target.transform.position.x > this.transform.position.x;
     
        if (Vector2.Distance(transform.position, target.position) < range)
        {
            //HINT 1 FOR LAB: CHECK SOMETHING PRIOR TO FIRING TO DETERMING WHICH DIRECTION TO FIRE - CAN ALSO INCLUDE DISTANCE
            if (Time.time >= timeSinceLastFire + projectileFireRate)
            {

                anim.SetBool("Fire", true);
                timeSinceLastFire = Time.time;
            }
        }
        else
        {
            ReturnToIdle();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);

    }






    public void Fire()
    {
        //HINT 2 FOR LAB: IF YOU KNOW THE DIRECTION - YOU CAN ADD LOGIC HERE TO FIRE IN THAT DIRECTION
       /* Projectile temp = Instantiate(projectilePrefab, SpawnPointLeft.position, SpawnPointLeft.rotation);
        temp.speed = -projectileForce;*/

        if (!sr.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = -projectileForce;
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileForce;
        }



    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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