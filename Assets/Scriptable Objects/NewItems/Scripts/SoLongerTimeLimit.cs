using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/SoLongerTimeLimit")]
public class SoLongerTimeLimit : ShopItemSO
{
    public Timers timers;
    public float increment;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        timers.timeToGetFireSwitches += increment;
    }
}
