using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class Spaceship : MonoBehaviourPun
{
    public GameObject firePrefab;
    public Transform fireTransform;
    public float speed = 10f;
    public float xMin, xMax;

    [SerializeField]
    TMP_Text txt;


    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            txt.text = photonView.Owner.NickName;
        }
    }
    void Update()
    {
         if (photonView.IsMine)
        {

            Move(Input.GetAxis("Horizontal"));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
           
        }

    }

    private void Move(float horizontal)
    {
        Vector3 paddlePos = transform.position;
        paddlePos.x += horizontal * speed * Time.deltaTime;
        paddlePos.x = Mathf.Clamp(paddlePos.x, xMin, xMax);
        transform.position = paddlePos;
    }

    private void Fire()
    {
        PhotonNetwork.Instantiate(firePrefab.name,fireTransform.position, fireTransform.rotation);
        //Instantiate(firePrefab, 

    }


    private void Hit()
    {

    }


    


}
