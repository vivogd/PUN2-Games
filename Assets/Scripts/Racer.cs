using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Racer : MonoBehaviourPun
{
    [SerializeField] GameObject[] carsPrefabs;
    [SerializeField] Transform cameraRig;

    public void SetCar(int carType)
    {
        photonView.RPC("CreateCar", RpcTarget.AllBuffered, carType);
        

        Camera.main.transform.SetParent(cameraRig);
        Camera.main.transform.position = cameraRig.position;
        Camera.main.transform.rotation = cameraRig.rotation;
    }


 

    [PunRPC]
    void CreateCar(int carType)
    {
        Instantiate(carsPrefabs[carType], transform);
    }
}
