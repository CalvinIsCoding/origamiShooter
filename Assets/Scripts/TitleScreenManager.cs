using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
   public RopeForPlayer ropeForPlayer;
    public CinemachineVirtualCamera virtualCamera;
    public bool titleCutSceneBegan;
    public bool titleCutSceneEnded;
    public GameObject background;
    public GameObject fireActivator;
    public PlayerController playerController;
    public GameObject[] titleScreenElements = new GameObject[4];
    public GameObject subtitle;
    public GameObject WASDKeys;
    void Start()
    {
        titleCutSceneBegan = false;
        WASDKeys.SetActive(false);
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
       /* if (titleCutSceneEnded && WASDKeys.activeInHierarchy == false)
        {
            
        }*/
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
        StartCoroutine(ShowWASD());
        StartCoroutine(MoveFireActivator());
        //Setting overheat time here so that player experiences overheating fan for a few seconds after title sequence and use WASD to move around.
        playerController.overHeatTime = 10f;
        virtualCamera.Follow = playerController.gameObject.transform;

    }
    IEnumerator ShowWASD()
    {
        WASDKeys.SetActive(true);
        yield return new WaitForSeconds(10f);
        WASDKeys.SetActive(false);

    }
    IEnumerator MoveFireActivator()
    {
        yield return new WaitForSeconds(12f);
        fireActivator.transform.position = new Vector3(1.6f, -0.8f, 0f);
    }
    

}
