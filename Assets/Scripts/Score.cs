using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score;
    public Text scoreText;
    

    // Update is called once per frame
    void Update()
    {
       scoreText.text = score.ToString() + "Pts";
    }
}
