using TMPro;
using UnityEngine;

public class SecondTimer : MonoBehaviour
{
    public TMP_Text originalTimer;
    public TMP_Text secondTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer.text = originalTimer.text;
    }
}
