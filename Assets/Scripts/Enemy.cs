using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Enemy : MonoBehaviourPun
{
    
    void Start()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
        {
            Invoke("KillMe", 6f);
        }
    }

    void KillMe()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    public void HitMe()
    {
        photonView.RPC("RPC_KillMe", RpcTarget.MasterClient);
    }

    [PunRPC]
    void RPC_KillMe()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
