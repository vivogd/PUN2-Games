using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class SpaceInvaders : MonoBehaviourPun
{
    public GameObject spaceshipPrefab;
    public Transform spawnTransform;
 
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            Hashtable myCustomProperties = new Hashtable();
            myCustomProperties["kills"] = 0;
            

          
            PhotonNetwork.LocalPlayer.SetCustomProperties(myCustomProperties);


            PhotonNetwork.Instantiate(spaceshipPrefab.name, spawnTransform.position, Quaternion.identity);
        }
        
       
    }

 
}
