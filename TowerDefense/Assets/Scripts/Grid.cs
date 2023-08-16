using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private GameObject overlayTile;
    [SerializeField]
    private GameObject containerForTiles;
    void Start()
    {
        Tilemap tileMap = GetComponentInChildren<Tilemap>();
        BoundsInt bounds = tileMap.cellBounds;
        for (int z = bounds.max.z; z > bounds.min.z; z-- )
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++ )
            {
                for (int x = bounds.min.x; x < bounds.max.x; x++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    Debug.Log("Helloo");
                    GameObject tile = Instantiate(overlayTile, containerForTiles.transform);
                    Vector3 cellWorldLocation = tileMap.GetCellCenterWorld(tileLocation);

                    tile.transform.position = new Vector3(cellWorldLocation.x, cellWorldLocation.y, cellWorldLocation.z + 1);
                    if (tileMap.HasTile(tileLocation))
                    {
                        
                        
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
