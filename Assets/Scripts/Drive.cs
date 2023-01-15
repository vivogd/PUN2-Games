using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Drive : MonoBehaviourPun
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        if (!photonView.IsMine) return;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += transform.forward * vertical * speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, horizontal * rotationSpeed * Time.deltaTime, 0));
    }
}