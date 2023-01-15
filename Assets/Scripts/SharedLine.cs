using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SharedLine : MonoBehaviourPun
{
    [SerializeField] LineRenderer lineRenderer;
    Color myColor;
    Draw draw;
    private void Start()
    {
       
    }

    public void CreateBrush(Vector2 mousePos, int colorIndex)
    {
         
        photonView.RPC("CreateSharedBrush", RpcTarget.AllBuffered, mousePos,colorIndex);
    }
    public void AddPoint(Vector2 mousePos, int colorIndex)
    {
        
        photonView.RPC("AddSharedPoint", RpcTarget.AllBuffered, mousePos, colorIndex);
    }


    [PunRPC]
    void CreateSharedBrush(Vector2 mousePos,int colorIndex)
    {
        draw = FindObjectOfType<Draw>();
        lineRenderer.material.color = draw.colors[colorIndex];
        lineRenderer.SetPosition(0, mousePos);
        lineRenderer.SetPosition(1, mousePos);
    }

    [PunRPC]
    void AddSharedPoint(Vector2 mousePos, int colorIndex)
    {
        lineRenderer.material.color = draw.colors[colorIndex];
        lineRenderer.positionCount++;
        int posIndex = lineRenderer.positionCount - 1; ;
        lineRenderer.SetPosition(posIndex, mousePos);
    }


    public void DestroyMe()
    {
        
    }
}
