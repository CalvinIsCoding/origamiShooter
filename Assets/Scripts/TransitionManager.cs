using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public Image fadeScreen;
    void Start()
    {
        fadeScreen.enabled = true;
        DontDestroyOnLoad(this.gameObject);
    }

   
}
