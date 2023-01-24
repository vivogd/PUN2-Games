using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      //  direction = Vector2.down * speed;
        Launch();
    }

    void Update()
    {
       if(PhotonNetwork.IsMasterClient)
        {
             rb.velocity = direction * speed;
        }


       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
 
       
        if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = transform.position.x - collision.transform.position.x;
            direction.y = -direction.y;

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;

        }
        else if (collision.gameObject.CompareTag("SideWall"))
        {
            direction.x = -direction.x;

        }
       
    }

    void Launch()
    {
       // float x = Random.Range(0, 2) == 0 ? -1 : 1;
        //float y = Random.Range(-0.5f, 0.5f);
        direction = new Vector2(1, -1).normalized;
        rb.velocity = direction * speed;
    }
}