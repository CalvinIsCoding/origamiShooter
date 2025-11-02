using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlescreenSceneManager : MonoBehaviour
{
    public GameObject[] titleScreenLetters = new GameObject[3];
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (titleScreenLetters[0] == null && titleScreenLetters[1] == null && titleScreenLetters[2] == null)
        {
            startGame();
        }
    }
    void startGame()
    {
        SceneManager.LoadScene("Game");
    }
}
