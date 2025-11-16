using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlescreenSceneManager : MonoBehaviour
{
    public GameObject[] titleScreenLetters = new GameObject[3];
    public Animator sceneTransitionAnimator;
    public float sceneTransitionTime = 1.0f;
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
        StartCoroutine(loadSceneDelay());
    }
    IEnumerator loadSceneDelay()
    {
        sceneTransitionAnimator.SetBool("Fade Out", true);
        
        yield return new WaitForSeconds(sceneTransitionTime);
        sceneTransitionAnimator.SetBool("Fade Out", false);
        SceneManager.LoadScene("Game");
    }
}
