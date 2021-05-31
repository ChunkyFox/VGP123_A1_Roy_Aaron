using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    public GameObject[] spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnedObject[1], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Objective Met");

            //end game logic goes here
        }
    }
}
