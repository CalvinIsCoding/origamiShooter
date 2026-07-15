using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Short Time Limit")]
public class SoShorterTimeLimit : ShopItemSO
{
    public float increment;
    public Timers timers;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        timers.timeToGetFireSwitches -= increment;
    }
}
