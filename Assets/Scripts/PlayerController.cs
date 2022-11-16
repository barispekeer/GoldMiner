using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 0.25f;
    void Start()
    {

    }


    void Update()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        transform.Translate(-yatay * speed, 0, -dikey * speed);
    }
}
