using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Heavy Weight")]
public class SoHeavyWeight : ShopItemSO
{
    public float massIncrement;
    public PlayerController player;
    public override void OnClearDowngrade()
    {
        playerInventory.currentShopItems.Remove(this);
        playerInventory.mass = playerInventory.massDefault;
        player.rb.mass = playerInventory.mass;
        base.OnClearDowngrade();
       
    }

    public override void OnPurchase()
    {
        player = FindAnyObjectByType<PlayerController>();
        base.OnPurchase();
        playerInventory.mass += massIncrement;
        player.rb.mass = playerInventory.mass;
    }
}
