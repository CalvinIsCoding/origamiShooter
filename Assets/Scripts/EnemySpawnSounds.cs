using UnityEngine;

public class EnemySpawnSounds : MonoBehaviour
{
    public int spawnerSoundsActiveNumber;
    public int lastSpawnerSoundActiveNumber;
    public AudioSource spawnSounds;
    public AudioClip spawnSound;
    void Start()
    {
        lastSpawnerSoundActiveNumber = 0;
        spawnerSoundsActiveNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerSoundsActiveNumber > 3)
        {
            spawnerSoundsActiveNumber = 3;
        }
        if (spawnerSoundsActiveNumber > 0)
        {
            spawnSounds.PlayOneShot(spawnSound);
            spawnerSoundsActiveNumber--;

        }

    }
}
