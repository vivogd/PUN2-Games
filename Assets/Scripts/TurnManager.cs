using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TurnManager : MonoBehaviourPunCallbacks
{
    public static TurnManager Instance;
    private int currentTurn = 0;
    private int playersInGame;

    void Start()
    {
        Instance = this;
        playersInGame = PhotonNetwork.PlayerList.Length;
    }

    public void NextTurn()
    {
        currentTurn = (currentTurn + 1) % playersInGame;
        photonView.RPC("RPC_UpdateTurn", RpcTarget.All, currentTurn);
    }

    [PunRPC]
    void RPC_UpdateTurn(int turn)
    {
        currentTurn = turn;
        Debug.Log("Player " + (currentTurn + 1) + " has the turn");
    }

    public int GetCurrentTurn()
    {
        return currentTurn;
    }
}
