using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject shopKeeper;
    public HUDController HUDManager;
    
    void Start()
    {
       
        HUDManager = FindAnyObjectByType<HUDController>();
        HUDManager.shopTouched = false;

        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            HUDManager.shopTouched = true;
            Destroy(this.gameObject);
        }

    }

   
    

}
