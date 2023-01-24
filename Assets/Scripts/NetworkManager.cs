using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
 

public class NetworkManager : MonoBehaviourPunCallbacks
{
    
    
    [SerializeField] UIManager uiManager;
    [SerializeField]
    int MaxPlayer;
    bool isFirstTime = true;

    void Start()
    {
        Debug.Log("SendRate" + PhotonNetwork.SendRate);
        Debug.Log("SerializationRate" + PhotonNetwork.SerializationRate);
        gameObject.tag = "Enemy";

        //Defines how many times per second the PhotonHandler should send data, 
     //   PhotonNetwork.SendRate = 10; //  Default: 30.

        //Defines how many times per second OnPhotonSerialize should be called on PhotonViews
//PhotonNetwork.SerializationRate = 30; //Default: 10.

        PhotonNetwork.ConnectUsingSettings();
        
        
        PhotonNetwork.NickName = "Player_" + Random.Range(0, 1000);
        uiManager.AddTitle(PhotonNetwork.NickName + " is connecting ");
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    void CreateRandomRoom()
    {
     
        //No random room available, so we create one
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;

        string roomName = "Room_" + Random.Range(0, 1000);

        PhotonNetwork.CreateRoom(roomName, roomOptions); // we can also put null in room name and photon will alocate a radom room
    }

    void LoadGame()
    {
        PhotonNetwork.LoadLevel(1);

    }



    #region Photon Callbacks

    public override void OnConnected()
    {
        Debug.Log("Connected to internet");
    }

    public override void OnConnectedToMaster()
    {


        PhotonNetwork.JoinRandomRoom();
        uiManager.AddTitle(PhotonNetwork.NickName + " is trying to join room");

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        uiManager.AddTitle("Joining room failed. Creating a room");
        CreateRandomRoom();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        CreateRandomRoom();
    }

    public override void OnCreatedRoom()
    {
        uiManager.AddTitle("Room "+PhotonNetwork.CurrentRoom.Name + " created");
    }


    public override void OnJoinedRoom()
    {

        uiManager.AddTitle(PhotonNetwork.NickName + " has joined a room" + PhotonNetwork.CurrentRoom.Name);
     
        if (PhotonNetwork.CurrentRoom.PlayerCount< PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            uiManager.AddTitle("Waiting for Player");
        }
        else
        {
            LoadGame();
        }
        
       
      

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        uiManager.AddTitle(newPlayer.NickName + " has Enterd the room");
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            LoadGame();
        }
    }














    #endregion



}
