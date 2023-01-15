using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] Text title;


    public void AddTitle(string value)
    {
        title.text += value + "\n";
    }

    public void SetTitle(string value)
    {
        title.text =  value + "\n";
    }
}
