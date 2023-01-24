using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Pong : MonoBehaviourPun
{
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    Transform spawnPointMaster;
    [SerializeField]
    Transform spawnPointClient;
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPointMaster.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPointClient.position, Quaternion.identity);
        }
       
    }

}
