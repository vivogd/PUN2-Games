using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Fire : MonoBehaviourPun
{
    public float speed = 10f;
    void Start()
    {
        Invoke("DestroyMe", 5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (photonView.IsMine)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                AddKillToPlayer();
                collision.GetComponent<Enemy>().HitMe();
                //PhotonNetwork.Destroy(collision.gameObject);
                   DestroyMe();
            }


        }
    }
    private void AddKillToPlayer()
    {
        Player owner = photonView.Owner;
        Debug.Log("owner - "+owner.NickName);
        if (owner.CustomProperties.ContainsKey("kills"))
        {
            


            int kills = (int) owner.CustomProperties["kills"];
            kills++;

            Hashtable myCustomProperties = new Hashtable();
            myCustomProperties["kills"] = kills;
            owner.SetCustomProperties(myCustomProperties);
       
        }
    }
}
