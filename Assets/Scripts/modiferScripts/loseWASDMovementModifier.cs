using UnityEngine;
using System;

[Serializable]


public class loseWASDMovementModifier : Modifier
{
    
    public override void OnPurchase(ScriptableObject scriptableObject)
    {

        //playerStats.loseWASDMovementEnabled = true;
        if(scriptableObject is PlayerInventory)
        {
            //do stuff
        }
        else
        {
            return;
        }
    }
    public override void OnClearDowngrades()
    {
       // playerStats.loseWASDMovementEnabled = playerStats.loseWASDMovementEnabledDefault;
    }
}
