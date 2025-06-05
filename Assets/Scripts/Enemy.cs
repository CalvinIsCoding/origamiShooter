using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 10;

	public GameObject enemy;
	public GameObject deathEffect;
	public Rigidbody2D rb;

	//Push() variables
	Vector2 positionVector;
	private float velocityMagnitude;
	private float positionMagnitude;
	private float blowTime = 0.50f;
	public bool isBlown;
	public Vector2 travelDirection;

	//private float speed;
	//private float lastTime;
	private float spawnDelayTime = 0.8f;
	private bool spriteToggle;
	private int blinks = 6;
	public SpriteRenderer sprite;

	public bool isBlink;

	public bool isWet;
	public GameObject wetPaper;

	

    
	public EnemySpawn enemySpawn;
	private int waveSpawned;
	private bool isRed;
	public int wavesSaved;
	//public ShopManager shopManager;
	public PlayerInventory playerInventory;
	public GameStatsScript gameStats;

	//Audio handling
	public AudioSource source;
	public AudioClip closedHiHat;
	public AudioClip snare;
	public AudioClip bassDrum;

	
	private int growthFrames = 30;
	private float currentScale;
	private float maxScale;
	void Start()
    {
		enemySpawn = FindObjectOfType<EnemySpawn>();
		//shopManager = FindObjectOfType<ShopManager>();
		isRed = false;
		isBlown = false;
		isBlink = true;
		spriteToggle = false;
		waveSpawned = enemySpawn.waveNumber;
		wavesSaved = 0;

		//StartCoroutine(Blink());
		currentScale = 0;
		maxScale = this.transform.localScale.x;
		StartCoroutine(GrowIntoExistance());
	}
    private void Update()
    {
		
        if (wavesSaved < (enemySpawn.waveNumber - waveSpawned) && !enemySpawn.fireMode.isFireMode)
        {
			
			wavesSaved = wavesSaved + 1;
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
		playerInventory.coinsBeforeMultiplier = playerInventory.coinsBeforeMultiplier + wavesSaved + 1;
		gameStats.enemiesKilledThisWave++;
		Destroy(gameObject);
		
	}
	public void Push(float knockBack, Rigidbody2D bullet,GameObject _bullet, Vector2 airBulletVelocity)
    {
		positionVector = new Vector2(_bullet.transform.position.x - enemy.transform.position.x, _bullet.transform.position.y - enemy.transform.position.y);
		positionMagnitude = Mathf.Sqrt(Mathf.Pow(positionVector.x, 2) + Mathf.Pow(positionVector.y, 2));

		velocityMagnitude = Mathf.Sqrt(Mathf.Pow(airBulletVelocity.x, 2) + Mathf.Pow(airBulletVelocity.y, 2));
		if (velocityMagnitude == 0)
        {
			velocityMagnitude = 1;
        }



          

		rb.AddForce(((airBulletVelocity / (2 * velocityMagnitude)) ) * knockBack , ForceMode2D.Force);
		//Debug.Log("Position Vetcor: " + positionVector/positionMagnitude);
		//Debug.Log("Velocity Vetcor: " + airBulletVelocity/ (2 * velocityMagnitude));
		//Debug.Log("Total Force: " + ((bullet.velocity / (2 * velocityMagnitude)) + (-positionVector / positionMagnitude)) * knockBack);

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
		switch (wavesSaved)
		{
			case (1):
				sprite.color = Color.red;
				
				break;

			case (2):
				sprite.color = Color.blue;
				break;

			case (3):
				sprite.color = Color.magenta;
				break;
		}

	}
	IEnumerator GrowIntoExistance()
    {
		for (int i = 0; i < growthFrames; i++)
		{
			currentScale += (maxScale / growthFrames);
			sprite.transform.localScale = Vector2.one * currentScale;
			yield return new WaitForSeconds(spawnDelayTime / growthFrames);
		}
		isBlink = false;
		
	}
	/*private void OnCollisionEnter2D(Collision2D collision)
    {
		Wall myWall = collision.gameObject.GetComponent<Wall>();

		Debug.Log("collision velocity: " + collision.relativeVelocity.magnitude);
		
        if (myWall != null &&  collision.relativeVelocity.magnitude > 4)
        {
			source.PlayOneShot(snare);
        }
        else if (myWall != null && collision.relativeVelocity.magnitude < 4 && collision.relativeVelocity.magnitude > 2)
        {
			source.PlayOneShot(bassDrum);
        }
		else if(myWall != null && collision.relativeVelocity.magnitude < 2)
        {
			source.PlayOneShot(closedHiHat);
		}
		
    }*/


}
