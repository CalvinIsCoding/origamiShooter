using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject shopKeeper;
    public ShopManager shopManager;
    public HUDController HUDManager;
    public Animator shopAnimator;
    
    
    void Start()
    {
       
        HUDManager = FindAnyObjectByType<HUDController>();
        HUDManager.shopTouched = false;

        //shopManager = FindAnyObjectByType<ShopManager>();
        //The Find gameobject functions generally don't work with inactive scene objects. This first finds the canvas object and then finds the component "shop manager" in any of it's children. 
        //The "true" overload in the getcomponent method makes the method find both active and inactive objects.
        shopMenu = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<ShopManager>(true).gameObject;



    }
    

    // Update is called once per frame
    void Update()
    {
        if(shopMenu.activeInHierarchy == true)
        {
            shopAnimator.SetBool("Shop Exited", true);
            Destroy(this.gameObject,0.33f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            HUDManager.shopTouched = true;
            Time.timeScale = 0;
            shopMenu.SetActive(true);
        }


    }

   
    

}
