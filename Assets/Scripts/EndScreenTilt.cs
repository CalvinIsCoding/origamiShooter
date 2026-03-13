using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EndScreenTilt : MonoBehaviour
{
    public CinemachineVirtualCamera Cinemachine;
    public float dutchAngle;
    public GameObject StickyNote;
    public bool gameIsOver;
    public PlayerController PlayerController;
    public int frames;
    public GameObject gameoverMenu;
    public bool cameraInPlace;
    public CinemachineVirtualCamera stickyNoteCamera;
    public GameObject enemySpawner;

    void Start()
    {
        dutchAngle = -18f;
        frames = 200;
        cameraInPlace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.playerDead && !cameraInPlace)
        {
           // StartCoroutine(moveCameraSlowly());
            // Cinemachine.
            //Cinemachine.m_Lens.Dutch = dutchAngle;
            //Cinemachine.Follow = StickyNote.transform;
            // Cinemachine.m_Lens.FieldOfView = 2;
            stickyNoteCamera.Priority = 20;
             cameraInPlace = true;
            enemySpawner.SetActive(false);
            StartCoroutine(waitForMenuToAppear());

        }
    }
    IEnumerator moveCameraSlowly()
    {
        for (int i = 0; i < frames; i++)
        {
            Cinemachine.m_Lens.Dutch = Cinemachine.m_Lens.Dutch + (dutchAngle / 200);
            Debug.Log("zooming" + i);
            yield return new WaitForFixedUpdate();
        }
        gameoverMenu.SetActive(true);
        
    }
    IEnumerator waitForMenuToAppear()
    {
        yield return new WaitForSeconds(3f);
        gameoverMenu.SetActive(true);
    }
}
