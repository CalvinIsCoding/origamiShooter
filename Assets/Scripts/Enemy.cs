using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 100;

	public GameObject enemy;
	public GameObject deathEffect;
	public Rigidbody2D rb;
	Vector2 positionVector;
	private float velocityMagnitude;
	private float positionMagnitude;

	//private float speed;
	//private float lastTime;
	private float spawnDelayTime = 0.8f;
	private bool spriteToggle;
	private int blinks = 6;
	public SpriteRenderer sprite;

	public bool isBlink;

	public bool isWet;
	public GameObject wetPaper;

	private float blowTime = 0.5f;
	public bool isBlown;
	public Vector2 travelDirection;

    
	public EnemySpawn enemySpawn;
	private int waveSpawned;
	private bool isRed;

	

	void Start()
    {
		enemySpawn = FindObjectOfType<EnemySpawn>();
		isRed = false;
		isBlown = false;
		isBlink = true;
		spriteToggle = false;
		waveSpawned = enemySpawn.waveNumber;
		
		StartCoroutine(Blink());
	}
    private void Update()
    {
		
        if (waveSpawned < enemySpawn.waveNumber && !isRed && !enemySpawn.fireMode.isFireMode)
        {
			Debug.Log("Turning Red");
			
			ColorTurn();
			
        }
    }

    public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		
		Destroy(gameObject);
		if (isRed)
        {
			Score.score = Score.score + 1;

		}
	}
	public void Push(float knockBack, Rigidbody2D bullet,GameObject _bullet)
    {
		positionVector = new Vector2(_bullet.transform.position.x - enemy.transform.position.x, _bullet.transform.position.y - enemy.transform.position.y);
		positionMagnitude = Mathf.Sqrt(Mathf.Pow(positionVector.x, 2) + Mathf.Pow(positionVector.y, 2));

		velocityMagnitude = Mathf.Sqrt(Mathf.Pow(bullet.velocity.x, 2) + Mathf.Pow(bullet.velocity.y, 2));
		if (velocityMagnitude == 0)
        {
			velocityMagnitude = 1;
        }



          

		rb.AddForce(((bullet.velocity / (2 * velocityMagnitude)) + (-positionVector / positionMagnitude) ) * knockBack , ForceMode2D.Impulse);

		if (isBlown == false)
		{
			isBlown = true;
			StartCoroutine(Blowing());
		}
		

	}

	IEnumerator Blink()
	{
		for (int i = 0; i < blinks; i++)
		{
			sprite.enabled = spriteToggle;
			spriteToggle = !spriteToggle;
			yield return new WaitForSeconds(spawnDelayTime / blinks);
		}
		isBlink = false;
	}

	public void WettingPaper()
    {
		if (!isWet)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);

			Instantiate(wetPaper, this.transform.position, transform.rotation);
			Destroy(this.gameObject);
		}
        
	}

	IEnumerator Blowing()
    {
		//isBlown = true;
		
		
		yield return new WaitForSeconds(blowTime);
		isBlown = false;


	}

	void ColorTurn()
    {
		sprite.color = Color.red;
		isRed = true;

	}


}
