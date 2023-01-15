using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SetColor : MonoBehaviourPun
{
    [SerializeField]
    Color myColor;
    void Start()
    {
        if (photonView.IsMine)
        {
            GetComponent<MeshRenderer>().material.color = myColor;
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
