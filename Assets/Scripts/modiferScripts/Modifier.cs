using UnityEngine;
using System;

[Serializable]
public abstract class Modifier
{
    
  // public PlayerInventory playerStats;

    public virtual void SetPlayerInventory(PlayerInventory playerInventory)
    {
        
    }
    
   // protected int modifierScore;
    public virtual void OnPurchase(ScriptableObject scriptableObject)
    {
       // scriptableObject.currentModifiers.Add(this);
        
    }
    public virtual void OnClearDowngrades()
    {

    }
    
    public virtual void ChooseDownGradeCounterpart()
    {

    }
}
