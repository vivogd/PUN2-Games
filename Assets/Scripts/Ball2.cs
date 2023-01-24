using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ball2 : MonoBehaviourPun
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  direction = Vector2.down * speed;
        Launch();
    }

    void Update()
    {

        rb.velocity = velocity;
        if (!PhotonNetwork.IsMasterClient) return;
 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!photonView.IsMine) return;
        direction = velocity;
        if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = transform.position.x - collision.transform.position.x;
            direction.y = -velocity.y;
            photonView.RPC("SetVelocity", RpcTarget.All, transform.position, direction);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -velocity.y;
            photonView.RPC("SetVelocity", RpcTarget.All, transform.position, direction);

        }
        else if (collision.gameObject.CompareTag("SideWall"))
        {
            direction.x = -velocity.x;
            photonView.RPC("SetVelocity", RpcTarget.All, transform.position, direction);

        }

    }

    void Launch()
    {
        direction = new Vector2(1, -1).normalized;
        photonView.RPC("SetVelocity", RpcTarget.All,transform.position,direction);
    }

    [PunRPC]
    public void SetVelocity(Vector3 pos, Vector2 dir)
    {
        Debug.Log("velocity " + velocity);
        transform.position = pos;
        velocity = dir * speed;
    }
}