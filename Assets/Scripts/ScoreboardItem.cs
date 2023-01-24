using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class ScoreboardItem : MonoBehaviourPunCallbacks
{

    public TMP_Text playerName;
    public TMP_Text kills;
    public TMP_Text deaths;

    Player player; 

    public void Init(Player _player)
    {
        player = _player;
        playerName.text = player.NickName;
    }


    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
       

        if (player == targetPlayer)
        {
            if (changedProps.ContainsKey("kills"))
            {
                kills.text = targetPlayer.CustomProperties["kills"].ToString();    
            }
        }
        
    }
}
