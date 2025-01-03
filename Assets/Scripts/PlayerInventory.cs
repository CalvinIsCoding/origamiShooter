using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Scriptable Objects/New Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public string title;
    public int coins = 0;
    public int lives = 10;

    [SerializeField] private int defaultCoins = 0;
    [SerializeField] private int defaultLives = 10;

    public void resetToDefaults()
    {
        lives = defaultLives;
        coins = defaultCoins;
    }
}

