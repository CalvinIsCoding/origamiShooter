using UnityEngine;

public class timerUIObject : MonoBehaviour
{
    public GameObject ClockEnemy;
    public Vector3 clockPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // clockPosition = this.transform.position;

    }
    void SpawnClockEnemy()
    {
        Instantiate(ClockEnemy);
    }
}
