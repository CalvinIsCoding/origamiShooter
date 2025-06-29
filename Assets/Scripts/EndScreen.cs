using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject regularEndScreen;
    public GameObject highlightedEndScreen;

    private void Start()
    {
        UnHighlightExitButton();
    }
    public void UnHighlightExitButton()
    {
        highlightedEndScreen.SetActive(false);
        regularEndScreen.SetActive(true);
    }
    public void HighlightExitButton()
    {
        highlightedEndScreen.SetActive(true);
        regularEndScreen.SetActive(false);  
        

    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Title Screen");
    }

}
