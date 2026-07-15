using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Tired Quicker")]
public class SoTiredQuicker : ShopItemSO
{
    public float incremement;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
        playerInventory.currentShopItems.Remove(this);
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.timeTillOverheat -= incremement;
       
    }
}
