using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class TurnGameManager : MonoBehaviourPun
{
    public Transform playerUIParent;
    public GameObject playerItemPrefab;

    void Start()
    {
        InitBoard();
    }


    void InitBoard()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
          //  GameObject _item  = PhotonNetwork.Instantiate(playerItemPrefab.name, Vector3.zero,Quaternion.identity);
          //  _item.transform.SetParent(playerUIParent);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNextTurnPressed()
    {
        TurnManager.Instance.NextTurn();
    }
}
