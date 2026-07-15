using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/More Enemies")]
public class SoMoreEnemies : ShopItemSO
{
    public GameObject waveSet;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
        playerInventory.currentShopItems.Remove(this);
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        waveSet = GameObject.FindWithTag("Wave Set");
        foreach (Wave wave in waveSet.GetComponentsInChildren<Wave>()) 
        {
            if (wave.randomSpawnDisabled == true && wave.bossWave == false)
            {
                wave.randomSpawnDisabled = false;
                wave.maxEnemiesSpawnedRandomly = 10;
            }
            else if (wave.randomSpawnDisabled == false) {

                wave.maxEnemiesSpawnedRandomly += 10;
            }
            
           
        }

    }
}
