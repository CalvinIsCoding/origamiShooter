using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/SoWallBounce")]
public class SoWallBounce : ShopItemSO
{
    public Wall wall;
    public PhysicsMaterial2D bouncyWallMaterial;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        wall = FindAnyObjectByType<Wall>();
        base.OnPurchase();
        wall.rb.sharedMaterial = bouncyWallMaterial;
        
    }
}
