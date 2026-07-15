using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "modifierAvailableList", menuName = "Scriptable Objects/modifierAvailableList")]
public class modifierAvailableList : ScriptableObject
{
    [SerializeReference]
    public List<Modifier> availableModifiers = new List<Modifier>(10);
    public List<testCustomClass> customClass = new List<testCustomClass>();
    
    public float testFloat;
}
