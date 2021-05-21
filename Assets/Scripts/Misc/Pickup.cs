using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES
    }

    public CollectibleType currentCollectible;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTIBLE:
                    PlayerMovement pmScript = collision.gameObject.GetComponent<PlayerMovement>();
                    pmScript.score++;
                    Debug.Log(pmScript.score);
                    break;

                case CollectibleType.LIVES:
                    pmScript = collision.gameObject.GetComponent<PlayerMovement>();
                    pmScript.lives++;
                    Debug.Log(pmScript.lives);
                    break;

                case CollectibleType.POWERUP:
                    collision.gameObject.GetComponent<PlayerMovement>().StartSpeedChange();
                    break;

            }

            Destroy(gameObject);
        }
    }
}