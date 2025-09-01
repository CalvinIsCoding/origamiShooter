using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FontSwap : MonoBehaviour
{
    //public TextMeshPro testTextSwap;
    public TMP_Text testFontSwap;
    
    public TMP_FontAsset[] tMP_FontAssets = new TMP_FontAsset[4];
    public bool started;
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (started == false)
        {
            StartCoroutine(swapFontNicely());
            started = true;
        }
    }
    IEnumerator swapFontNicely()
    {
        for (int i = 0; i < tMP_FontAssets.Length; i++)
        {
            //Debug.Log("changing font" + testFontSwap.font.name);
            testFontSwap.font = tMP_FontAssets[i];
            yield return new WaitForSeconds(0.1f);
        }
        started = false;
    }

}
