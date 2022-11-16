using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text scoreTxt, timeTxt;
    public Image pnl;
    Rigidbody rigi;
    float speed = 0.1f;
    float time = 10f;
    int score = 0;
    public bool gameActive = false;
    void Start()
    {
        gameActive = true;
        rigi = GetComponent<Rigidbody>();
        scoreTxt.text = "GOLD: " + score + " / 4";
    }


    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = "TIME: " + (int)time;
        if (gameActive)
        {
            if (time > 0)
            {
                float yatay = Input.GetAxis("Horizontal");
                float dikey = Input.GetAxis("Vertical");
                transform.Translate(yatay * speed, 0, dikey * speed);
            }
            else
            {
                gameActive = false;
                pnl.gameObject.SetActive(true);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Coin"))
        {
            score++;
            scoreTxt.text = "GOLD: " + score + " / 4";
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Respawn"))
        {
            pnl.gameObject.SetActive(true);
            gameActive = false;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
