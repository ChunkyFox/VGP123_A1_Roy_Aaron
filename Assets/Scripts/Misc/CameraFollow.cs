using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float minXClamp = -0.07f;
    public float maxXClamp = 56.93f;
    public float minYClamp = -0.2f;
    public float maxYClamp = 2.09f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            //create a variable to store the camera's x, y and z position
            Vector3 cameraTransform;

            //take my position values and put them in the variable
            cameraTransform = transform.position;

            cameraTransform.x = player.transform.position.x - 0.5f;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);
            cameraTransform.y = Mathf.Clamp(cameraTransform.y, minYClamp, maxYClamp);
            transform.position = cameraTransform;
        }
    }
}

