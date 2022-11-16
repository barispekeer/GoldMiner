using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float speed = 5;
    void Start()
    {
        player = transform.parent.gameObject;
    }

    
    void Update()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        player.transform.Rotate(0, xMouse*speed, 0,Space.World);
        player.transform.Rotate(yMouse*speed, 0, 0,Space.World);
    }
}
