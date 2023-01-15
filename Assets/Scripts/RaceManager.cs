using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RaceManager : MonoBehaviourPun
{
   
    [SerializeField] Transform StartTransform;
    [SerializeField] float distanceBetweenRaceres;
    GameObject localRacer;
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            CreateMyCar();
            SetCamera();
        }
    }


    void CreateMyCar()
    {
        Debug.Log("Player " + PhotonNetwork.LocalPlayer.ToString());
        localRacer = PhotonNetwork.Instantiate("Racer", StartTransform.position, Quaternion.identity);
        localRacer.transform.position += Vector3.right * distanceBetweenRaceres * PhotonNetwork.CountOfPlayersInRooms;
        
        
        localRacer.GetComponent<Racer>().SetCar(PhotonNetwork.CountOfPlayersInRooms);
       
    }

    void SetCamera()
    {
        
    }

   
}
