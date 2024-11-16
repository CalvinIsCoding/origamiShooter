using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Scriptable Objects/New Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public string title;
    public int coins = 0;
    public int lives = 10;
}

