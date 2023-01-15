using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
   Camera cam;
    private void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;

    }
    private void Update()
    {
        Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
