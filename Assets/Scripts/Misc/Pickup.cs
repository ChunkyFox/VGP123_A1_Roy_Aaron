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
    public AudioClip pickupAudioClip;

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
            PlayerMovement curMovementScript = collision.GetComponent<PlayerMovement>();
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTIBLE:
                    GameManager.instance.score++;
                    break;
                case CollectibleType.LIVES:
                    GameManager.instance.lives++;
                    break;
                case CollectibleType.POWERUP:
                    collision.gameObject.GetComponent<PlayerMovement>().StartJumpForceChange();
                    break;

            }

            if (pickupAudioClip && curMovementScript)
                curMovementScript.CollectibleSound(pickupAudioClip);

            Destroy(gameObject);
        }
    }
}