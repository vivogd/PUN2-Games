using UnityEngine;
using Photon.Pun;
using TMPro;

public class Paddle : MonoBehaviourPun
{
    public float speed = 10f;
    public float xMin, xMax;

    [SerializeField]
    TMP_Text txt;


    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            txt.text = photonView.Owner.NickName;
        }
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 paddlePos = transform.position;
            paddlePos.x += horizontal * speed * Time.deltaTime;
            paddlePos.x = Mathf.Clamp(paddlePos.x, xMin, xMax);
            transform.position = paddlePos;
        }
        
    }
}
