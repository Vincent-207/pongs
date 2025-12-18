using System;
using TMPro;
using UnityEngine;

public class WinDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text winText;
    [SerializeField]
    Color blueColor, redColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(GameInfo.blueScore > GameInfo.redScore)
        {
            winText.color = blueColor;
            winText.text = "Blue";
        }
        else if(GameInfo.blueScore < GameInfo.redScore)
        {
            winText.color = redColor;
            winText.text = "Red";
        }
        else
        {
            winText.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
