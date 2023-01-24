using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    public Transform itemsContainer;
    public GameObject itemPrefab;

    Dictionary<Player,ScoreboardItem> items = new Dictionary<Player,ScoreboardItem>();  


    private void Start()
    {

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddPlayer(player);

        }

    }
    void AddPlayer(Player player)
    {
        ScoreboardItem item = Instantiate(itemPrefab, itemsContainer).GetComponent<ScoreboardItem>();
        item.Init(player);
        //Add to dictionary
//        items[player]=  item;
        items.Add(player, item);
    }

    void RemovePlayer(Player player)
    {
        Destroy(items[player].gameObject);
        items.Remove(player);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayer(newPlayer);

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemovePlayer(otherPlayer);
    }

}
