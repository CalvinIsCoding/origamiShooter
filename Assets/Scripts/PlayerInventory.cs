using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Scriptable Objects/New Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public string title;
    public int coins = 0;
    public int lives = 10;
    public int coinsBeforeMultiplier;
    public float multiplier;

    [SerializeField] private int defaultCoins = 0;
    [SerializeField] private int defaultLives;

    public void resetToDefaults()
    {
        lives = defaultLives;
        coins = defaultCoins;
        coinsBeforeMultiplier = 0;
        multiplier = 0f;
    }
}

