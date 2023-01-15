using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Draw : MonoBehaviourPun
{


    [SerializeField]
    GameObject clearButton;

    [SerializeField]
    GameObject brushPrefab;

    SharedLine currentLine;
    Camera cam;
    Vector2 lastPos;

    [SerializeField]
    CustomCursor myCursor;

    public Color[] colors;
    int colorIndex = 0;

    void Start()
    {
        cam = Camera.main;
        myCursor = FindObjectOfType<CustomCursor>();
        myCursor.SetColor(colors[colorIndex]);

         clearButton.SetActive(PhotonNetwork.IsMasterClient);
    }




    public void OnClearAllPressed()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.DestroyAll();
        }
       
    }

    public void OnClearMinePressed()
    {
        SharedLine[] lines = FindObjectsOfType<SharedLine>();
        foreach (SharedLine line in lines)
        {

            if (line.GetComponent<PhotonView>().IsMine)
            {
                PhotonNetwork.Destroy(line.gameObject); 
            }

        }

    }


    [PunRPC]
    public void ClearAll()
    {

        SharedLine[] lines = FindObjectsOfType<SharedLine>();
        foreach (SharedLine line in lines)
        {

            PhotonNetwork.Destroy(line.gameObject);

        }
    
       
    }


    void CreateBrush()
    {
        GameObject brush = PhotonNetwork.Instantiate("brushPrefab", Vector3.zero, Quaternion.identity);
        currentLine = brush.GetComponent<SharedLine>();
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentLine.CreateBrush(mousePos, colorIndex);


    }


    void AddPoint(Vector2 mousePos)
    { 
        currentLine.AddPoint(mousePos, colorIndex);

    }


    void ChangeColor()
    {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            myCursor.SetColor(colors[colorIndex]);
        }
      
    }
    void Update()
    {
        
 
        if (Input.GetMouseButtonDown(0))
        {
            CreateBrush();
        }
        if (Input.GetMouseButton(0))
        {
           
            Vector2 currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (lastPos!= currentPos)
            {
                AddPoint(currentPos);
                lastPos = currentPos; 
               
            }
        }
        else
        {
            currentLine = null;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }

    }
}
