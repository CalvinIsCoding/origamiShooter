
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]

public class GameAdjustments : EditorWindow
{
    public AirBullet bullet;
    //public playerController player;
    //public FireMode fireMode;

    public paperBoat paperBoat;
    public float scale;

    //float bulletSpeed;

    [MenuItem("Tools/GameAdjustments")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GameAdjustments));
    }

    private void OnGUI()
    {
        GUILayout.Label("Adjust Gameplay", EditorStyles.boldLabel);

        bullet.speed = EditorGUILayout.Slider("Bullet Speed", bullet.speed, 0.5f, 6f);
        bullet.knockBack = EditorGUILayout.Slider("Bullet Knock Back", bullet.knockBack, 0.5f, 2f);
        paperBoat.boatMovementForce = EditorGUILayout.Slider("Boat Speed", paperBoat.boatMovementForce, 0.5f, 20f);


        /*player = EditorGUILayout.ObjectField("Player",player,typeof(playerController),true) as playerController;
        player.movementThrust = EditorGUILayout.Slider("Movement Speed", player.movementThrust, 1f, 20f);
        fireMode = EditorGUILayout.ObjectField("fire Mode", fireMode, typeof(FireMode), true) as FireMode;
        fireMode.timeTillFire = EditorGUILayout.Slider("Time Till Fire", fireMode.timeTillFire, 1f, 30f);
        fireMode.fireModeTime = EditorGUILayout.Slider("Firemode Time", fireMode.fireModeTime, 1f, 20f);*/
       


    }
    
}
