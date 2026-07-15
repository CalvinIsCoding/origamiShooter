using UnityEngine;

[CreateAssetMenu(fileName = "WallCharacteristics", menuName = "Scriptable Objects/WallCharacteristics")]
public class WallCharacteristics : ScriptableObject
{
    public float wallBounciness;
    private void OnEnable()
    {
        wallBounciness = 0f;
    }
}
