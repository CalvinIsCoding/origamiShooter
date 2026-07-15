using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Dark Arena")]
public class SoDarkArena : ShopItemSO
{
    public GameObject globalLightObject;
    public Light2D light;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
        playerInventory.currentShopItems.Remove(this);
    }

    public override void OnPurchase()
    {
        globalLightObject = GameObject.FindWithTag("Global Light");
        light = globalLightObject.GetComponent<Light2D>();
        light.intensity = 0.05f;
        base.OnPurchase();
        
    }
}
