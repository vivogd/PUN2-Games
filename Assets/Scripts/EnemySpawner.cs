using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemySpawner : MonoBehaviourPun
{
    public GameObject enemyPrefab;

     float rate = 0.004f; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.IsMasterClient)
        {
            if (Random.value< rate)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-4f, 4f);
        float randomY = Random.Range(0f, 4f);
        PhotonNetwork.Instantiate(enemyPrefab.name, new Vector2(randomX, randomY), Quaternion.identity);
     
    }
}
