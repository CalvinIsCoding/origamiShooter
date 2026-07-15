using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public float enemyScaleModifier;

    public void OnEnable()
    {
        enemyScaleModifier = 1.0f;
    }
    public void resetValues()
    {
        enemyScaleModifier = 1.0f;
    }
}
