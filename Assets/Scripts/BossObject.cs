using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

[CreateAssetMenu(fileName = "Boss", menuName = "Scriptable Objects/New Boss")]
public class BossObject : ScriptableObject
{
    public string bossName;
    public int health;
    public bool bossIsDead;
    public void resetToDefaults()
    {
        bossIsDead = false;
    }

}


