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
    public GameObject RopeObject;
    public AudioSource titleScreenAudioSource;
    public float activatorWaitTime;
    public float overheatTimeAfterRopeBreak;
    void Start()
    {
        titleCutSceneBegan = false;
        WASDKeys.SetActive(false);
        activatorWaitTime = 12f;
        overheatTimeAfterRopeBreak = 10f;
        titleScreenAudioSource.pitch = 0.2f;
        
        if (PlayerPrefs.HasKey("TitleScreenWithoutRope"))
        {
            RopeObject.SetActive(false);
            activatorWaitTime = 1f;
            overheatTimeAfterRopeBreak = 0f;
            Destroy(fireActivator);
            
        }
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteKey("TitleScreenWithoutRope");
        }

        
       
    }
    IEnumerator SpawnLetters()
    {
        for (int i = 0; i < titleScreenElements.Length - 1; i++)
        {
            titleScreenElements[i].SetActive(true);
            yield return new WaitForSeconds(1f);
            

        }
       // subtitle.SetActive(true);
        playerController.enabled = true;
        titleScreenAudioSource.Stop();
        titleScreenAudioSource.pitch = 1.0f;
        
        if (!PlayerPrefs.HasKey("TitleScreenWithoutRope"))
        {
            StartCoroutine(ShowWASD());
            StartCoroutine(MoveFireActivator());
            titleScreenAudioSource.pitch = 0.5f;
        }
        
        titleScreenAudioSource.Play();
        titleScreenElements[3].SetActive(true);
        
        
        //Setting overheat time here so that player experiences overheating fan for a few seconds after title sequence and use WASD to move around.
        playerController.overHeatTime = overheatTimeAfterRopeBreak;
        virtualCamera.Follow = playerController.gameObject.transform;
        PlayerPrefs.SetInt("TitleScreenWithoutRope", 1);
        

    }
    IEnumerator ShowWASD()
    {
        WASDKeys.SetActive(true);
        yield return new WaitForSeconds(10f);
        WASDKeys.SetActive(false);

    }
    IEnumerator MoveFireActivator()
    {
        yield return new WaitForSeconds(activatorWaitTime);
        fireActivator.transform.position = new Vector3(1.6f, -0.8f, 0f);
    }
    

}
