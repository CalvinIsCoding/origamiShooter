using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Timers", menuName = "Scriptable Objects/New Timers")]
public class Timers : ScriptableObject
{
    public float fireModeTime = 4f;
    public float lullAfterFireModeEndsButWaveHasntBegun = 3f;
    public float timeShopSticksAround = 10f;
    public float timeForRoundMoneyToCountUp;
    public float numbersSlammingTogetherTime = 0.75f;
    public float roundMoneyAddingTime = 1f;



}
