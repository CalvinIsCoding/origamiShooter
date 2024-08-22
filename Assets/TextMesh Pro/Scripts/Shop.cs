using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopMenu;
    void Start()
    {
        
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
            LaunchShop();
        }

    }

    void LaunchShop()
    {
       
        Time.timeScale = 0;
        ShopMenu.SetActive(true);



    }
    public void ExitShop()
    {
        Time.timeScale = 1;
        ShopMenu.SetActive(false);
    }

}
