using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasScript : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI score;
    public TextMeshProUGUI powerTimer;

    void Update()
    {
        score.text = "Score: " + player.GetComponent<SnakeScript>().score.ToString();
        powerTimer.text = player.GetComponent<SnakeScript>().powerTimer.ToString();
    }
}
