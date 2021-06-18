using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{

    AudioSource hitAudioSource;
    public AudioClip hitSFX;
    public AudioMixerGroup audioMixer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            
            GameManager.instance.lives--;
          
            // Debug.Log("Projectile collison");
            Destroy(collision.gameObject);      
        }
          
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.lives--;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Victory")
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }

    private void OnCollision2D(Collider2D collision)
    {
        if (!hitAudioSource)
        {
            hitAudioSource = gameObject.AddComponent<AudioSource>();
            hitAudioSource.clip = hitSFX;
            hitAudioSource.outputAudioMixerGroup = audioMixer;
            hitAudioSource.loop = false;
        }
        hitAudioSource.Play();
    }
}
