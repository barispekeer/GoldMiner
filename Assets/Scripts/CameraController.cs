using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //GameObject player;
    //float speed = 5;
    float hassasiyet = 1.5f;
    float yumusaklik = 2f;
    Vector2 gecisPos, camPos;
    GameObject player;
    PlayerController pc;
    void Start()
    {
        //player = transform.parent.gameObject;
        player = transform.parent.gameObject;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        //float xMouse = Input.GetAxis("Mouse X");
        //float yMouse = Input.GetAxis("Mouse Y");
        //player.transform.Rotate(0, xMouse*speed, 0,Space.World);
        //player.transform.Rotate(yMouse*speed, 0, 0,Space.World);
        if (pc.gameActive)
        {
            Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            farePos = Vector2.Scale(farePos, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));
            gecisPos.x = Mathf.Lerp(gecisPos.x, farePos.x, 1f / yumusaklik);
            gecisPos.y = Mathf.Lerp(gecisPos.y, farePos.y, 1f / yumusaklik);
            camPos += gecisPos;

            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(camPos.x, player.transform.up);
        }
        
    }
}
