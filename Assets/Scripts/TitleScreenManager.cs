using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
   public RopeForPlayer ropeForPlayer;
    public CinemachineVirtualCamera virtualCamera;
    public bool titleCutSceneBegan;
    public GameObject background;
    public PlayerController playerController;
    public GameObject[] titleScreenElements = new GameObject[4];
    public GameObject subtitle;
    void Start()
    {
        titleCutSceneBegan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ropeForPlayer.isActiveAndEnabled == false && titleCutSceneBegan == false)
        {
            virtualCamera.Follow = background.transform;
            
            titleCutSceneBegan = true;
            playerController.enabled = false;
            StartCoroutine(SpawnLetters());
        }
    }
    IEnumerator SpawnLetters()
    {
        for (int i = 0; i < titleScreenElements.Length; i++)
        {
            titleScreenElements[i].SetActive(true);
            yield return new WaitForSeconds(2f);
            
        }
       // subtitle.SetActive(true);
        playerController.enabled = true;
        virtualCamera.Follow = playerController.gameObject.transform;

    }
    

}
