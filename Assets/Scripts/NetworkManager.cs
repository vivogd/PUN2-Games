using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
 

public class NetworkManager : MonoBehaviourPunCallbacks
{
    
    
    [SerializeField] UIManager uiManager;
    bool isFirstTime = true;

    void Start()
    {
        Debug.Log("SendRate" + PhotonNetwork.SendRate);
        Debug.Log("SerializationRate" + PhotonNetwork.SerializationRate);


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
        roomOptions.MaxPlayers = 15;

        ExitGames.Client.Photon.Hashtable roomCustomProps = new ExitGames.Client.Photon.Hashtable();
        roomCustomProps.Add("Color", "Blue");
        roomCustomProps.Add("Level", "Easy");

        roomOptions.CustomRoomProperties = roomCustomProps;

        
        string[] customPropertiesForLobby = { "Color", "Level" };

        roomOptions.CustomRoomPropertiesForLobby = customPropertiesForLobby;




        string roomName = "Room_" + Random.Range(0, 1000);

        PhotonNetwork.CreateRoom(null, roomOptions); // we can also put null in room name and photon will alocate a radom room
    }


    private void CreateCustomProperty()
    {


        ExitGames.Client.Photon.Hashtable myCustomProperties;

        myCustomProperties = new ExitGames.Client.Photon.Hashtable();

        myCustomProperties["Age"] = Random.Range(10, 30);
        myCustomProperties["Score"] = 0;
        PhotonNetwork.LocalPlayer.SetCustomProperties(myCustomProperties);

        Debug.Log("my Age " + PhotonNetwork.LocalPlayer.CustomProperties["Age"].ToString());
    }


    #region Photon Callbacks

    public override void OnConnected()
    {
        Debug.Log("Connected to internet");
    }

    public override void OnConnectedToMaster()
    {

        //The first we try to do is to join a potential existing room.
        PhotonNetwork.JoinRandomRoom();
        uiManager.AddTitle(PhotonNetwork.NickName + " is trying to join room");
        CreateCustomProperty();
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
     


        if (PhotonNetwork.IsMasterClient)
        {
             PhotonNetwork.LoadLevel(1);
        }
      

    }


    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("Age"))
        {
            // update tagetPlayer age
        }
    }












    #endregion



}
