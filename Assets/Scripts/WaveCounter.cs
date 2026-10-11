using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    public GameStatsScript gameStats;
    public TMP_Text waveNumberText;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        waveNumberText.text = gameStats.wavesSurvived.ToString();
    }
}
