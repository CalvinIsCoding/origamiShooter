using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    //Movement Variables
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 currentVelocity;
    [SerializeField]
    private float movementSpeed = 12f;
    public Rigidbody2D characterRigidBody;

    public int lifeCount;
    
    



    //Shooting Variables
    public GameObject bulletPrefab;
    private GameObject bullet;
    public GameObject Player;
    public GameObject parryBox;
    public CapsuleCollider2D parryBoxCollider;
    private float movementThrust = 5f;
    

    public float currentTime;
    public float timePerBullet = 0.2f;


    public Transform firePoint;

    //reanimation variables




    void Start()
    {
        characterRigidBody = GetComponent<Rigidbody2D>();
        parryBoxCollider = parryBox.GetComponent<CapsuleCollider2D>();
        parryBox.SetActive(false);
        lifeCount = 3;
        currentTime = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        currentVelocity = characterRigidBody.velocity;
        


        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg);

        currentTime = currentTime + Time.deltaTime;
        //parry
        if (Input.GetButtonDown("Fire2"))
        {
            //parryBox =  Instantiate(parryBox, firePoint.position, firePoint.rotation,Player.transform);
            parryBox.SetActive(true);
            Boost();
            StartCoroutine(disableParryBox());
        }


        //shooting
        if (Input.GetButton("Fire1") && (currentTime - timePerBullet) > 0)
        {


            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            currentTime = 0;




        }


    }

    private void FixedUpdate()
    {
      
        // aCcounts for diagnoal movement. Makes it the same total velocity
        if (moveHorizontal != 0 && moveVertical != 0)
        {

           // characterRigidBody.velocity = new Vector2(moveHorizontal * movementSpeed * 0.707f, moveVertical * movementSpeed * 0.707f);
            characterRigidBody.AddForce(new Vector2(movementThrust * moveHorizontal * movementSpeed * 0.707f, movementThrust * moveVertical * movementSpeed * 0.707f));
        }
        
        else
        {
            //characterRigidBody.velocity = new Vector2(moveHorizontal * movementSpeed, moveVertical * movementSpeed);
            characterRigidBody.AddForce(new Vector2(movementThrust * moveHorizontal * movementSpeed, movementThrust * moveVertical * movementSpeed));
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        EnemyProjectile enemyProjectile = collision.gameObject.GetComponent<EnemyProjectile>();
         if (enemy != null)
        {
            Destroy(enemy.gameObject);
            
            PlayerDeath();
            
        }
        if (enemyProjectile != null)
        {
            Destroy(enemyProjectile.gameObject);

            PlayerDeath();

        }
    }

   /* void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            Destroy(enemy.gameObject);

            PlayerDeath();

        }
    }*/
    private void PlayerDeath()
    {
        lifeCount--;
        
        

        if (lifeCount <= 0)
        {
            SceneManager.LoadScene("Menu");
            
            
        }

    }

    IEnumerator disableParryBox()
    {
        yield return new WaitForSeconds(0.2f);
        parryBox.SetActive(false);
    }
    private void Boost()
    {
        Debug.Log("boosting");
        characterRigidBody.AddForce((Player.transform.position - firePoint.position) * 10f,ForceMode2D.Impulse);
    }
   
}
