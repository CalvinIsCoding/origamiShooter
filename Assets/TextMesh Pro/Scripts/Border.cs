using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Border : MonoBehaviour
{
    public static Border instance;
    public Tilemap tilemap;
    private void Awake()
    {
        instance = this;
    }
    
    public void DestroyBorder(Vector3 explosionLocation, int radius)
    {
        for (int x = -radius; x < radius; x++)
        {
            for (int y = -radius; y < radius; y++)
            {
                if (Mathf.Pow(x, 2) + Mathf.Pow(y, 2) < Mathf.Pow(radius, 2))
                {


                    Vector3Int tilePos = tilemap.WorldToCell(explosionLocation + new Vector3(x, y, 0));
                    if (tilemap.GetTile(tilePos) != null)
                    {
                        DestroyTile(tilePos);
                    }
                }

            }
        }
    }


    void DestroyTile(Vector3Int tilePos)
    {
        tilemap.SetTile(tilePos, null);
       

    }
}
