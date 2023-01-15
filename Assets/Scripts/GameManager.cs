using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] UIManager uiManager;
    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            uiManager.SetTitle(PhotonNetwork.NickName + " Is connected to" + PhotonNetwork.CurrentRoom);
            
            
            
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
        }
    }

    public void LeaveRoomClicked()
    {
        PhotonNetwork.LeaveRoom();
    }


    #region Photon Callbacks


    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(0);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CountOfPlayers == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            uiManager.SetTitle("Good to go!");
            uiManager.AddTitle("--" + PhotonNetwork.CurrentRoom);
        }
        else if (PhotonNetwork.CountOfPlayers < PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            uiManager.SetTitle("Not enough Players");
            uiManager.AddTitle("--"+PhotonNetwork.CurrentRoom);
        }
    }


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
         
    }
    #endregion


}
