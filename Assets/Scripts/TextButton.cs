using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextButton : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public TMP_FontAsset whiteFont;
    public TMP_FontAsset yellowFont;
   
   // public Color yellowColor = new Color(1f, 0.75f, 0.25f);
   // public Color whiteColor = new Color(1f, 1f, 1f);

    //very difficult to edit the underlay of a font separately on one text asset, so swapping the font is probably the easiest method.
    public void HighlightText()
    {
        textMeshPro.font = yellowFont;
        
    }
    public void UnHighlightText()
    {
       textMeshPro.font = whiteFont;
    }
}
