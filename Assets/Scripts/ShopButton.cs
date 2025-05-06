using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public int ItemID;
    public TMP_Text PriceText;
    public TMP_Text TitleText;
    public GameObject ShopManager;
    public Image ShopImage;
    public Animator ShopButtonAnimator;

    
    void Update()
    {
        
    }
    public void HoverOverButton()
    {
        ShopButtonAnimator.SetBool("hovering", true);
        Debug.Log("hovering is true");
        //hovering = true;
    }
    public void HoverOffButton()
    {
       ShopButtonAnimator.SetBool("hovering", false);
        Debug.Log("hovering is false");
        //hovering = false;
    }
}
