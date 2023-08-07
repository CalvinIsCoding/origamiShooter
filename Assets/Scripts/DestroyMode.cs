using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMode : MonoBehaviour
{
    public bool isDestroyMode;
    private float timeSinceDestroy;
    public float destroyModeTime = 0f;
    void Start()
    {
        isDestroyMode = false;
        timeSinceDestroy = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDestroy = timeSinceDestroy + Time.deltaTime;
        if ((timeSinceDestroy - destroyModeTime) > 0)
        {
            isDestroyMode=true;
            timeSinceDestroy = 0f;
        }
    }
}
