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
    public float multiplierMultiplier;
    public float multiplierAdder;
    public int downgradesPurchased;
    
   

    [SerializeField] private int defaultCoins = 0;
    [SerializeField] private int defaultLives;

    //Stats

    public float baseSpeed;
    public bool backStreamEnabled;
    public bool loseWASDMovementEnabled;
    public float timeTillOverheat;
    public float airBulletSize;
    public float airBulletSpeed;
    public int maxLives;
    public float mass;
    public float knockBack;
    public float BulletLivingTime;
    public float BulletShrinkTime;

    //Default Stats
    //These are here so that I can reference a default value in the modifier scripts instead of having a magic number.
    public readonly float baseSpeedDefault = 3.4f;
    public readonly bool backStreamEnabledDefault = false;
    public readonly bool loseWASDMovementEnabledDefault = false;
    public float timeTillOverheatDefault = 5f;
    public float airBulletSizeDefault = 0.6f;
    public float airBulletSpeedDefault = 5f;
    public int maxLivesDefault = 25;
    public float massDefault = 1f;
    public float knockBackDefault = 15f;
    public int requiredActivators;
    public int requiredActivatorsDefault = 3;
    public float BulletLivingTimeDefault = 0.8f;
    public float BulletShrinkTimeDefault = 0.5f;

    [SerializeReference]
    public List<Modifier> currentModifiers = new List<Modifier>();
    public List<ShopItemSO> currentShopItems = new List<ShopItemSO>();
    public void resetToDefaults()
    {
        lives = defaultLives;
        coins = defaultCoins;
        coinsBeforeMultiplier = 0;
        multiplier = 0f;
        multiplierAdder = 0f;
        multiplierMultiplier = 1f;
        downgradesPurchased = 0;
        currentShopItems.Clear();
        baseSpeed = baseSpeedDefault;
        timeTillOverheat = timeTillOverheatDefault;
        maxLives = maxLivesDefault;
        airBulletSize = airBulletSizeDefault;
        airBulletSpeed = airBulletSpeedDefault;
        mass = massDefault;
        knockBack = knockBackDefault;
        requiredActivators = requiredActivatorsDefault;
        BulletLivingTime = BulletLivingTimeDefault;
        BulletShrinkTime = BulletShrinkTimeDefault;


}
    public void EndOfWave()
    {
        coinsBeforeMultiplier = 0;
    }

}

