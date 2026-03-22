using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject regularEndScreen;
    public GameObject highlightedEndScreen;
    public CinemachineVirtualCamera playerCam;
    public GameObject playerSpawn;
    public GameObject gameoverUI;

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
        playerCam.Follow = playerSpawn.transform;
        playerCam.Priority = 30;
        gameoverUI.SetActive(false);
        
        StartCoroutine(WaitForCameraToMove());
        
    }

    public void Exit()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public IEnumerator WaitForCameraToMove()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }

}
