using UnityEngine;

public class NonEnemyObjectManager : MonoBehaviour
{
    public ShopItemSO furniture;
    public GameObject furniturePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (furniture.numberPurchased > 0)
        {
            furniturePrefab.SetActive(true);
        }
        else
        {
            furniturePrefab.SetActive(false);

        }

    }
}
