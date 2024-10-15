using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour
{
    public enum tileType
    {
        NORMAL = 0,
        ENEMY,
        RACING,
        NO_STATIC,
        NO_DYNAMIC
    }
    public tileType type;
    public tileType currentTile;

    public GameObject tileMover;

    public GameObject normalTile;
    public GameObject enemyTile;
    public GameObject racingTile;
    public GameObject noTile;

    public int tile;
    public GameObject SpawnTile;

    void Start()
    {
        for (int i = 1; i < 20; i++)
        {
            SelectTile();
            Instantiate(SpawnTile, new Vector3(0, -1, i), Quaternion.identity, tileMover.transform);
        }
        MakeTile();
    }

    void Update()
    {
        
    }

    public void MakeTile()
    {
        SelectTile();
        Instantiate(SpawnTile, new Vector3(0, -1, 20), Quaternion.identity, tileMover.transform);
    }

    public void SelectTile()
    {
        tile = Random.Range(0, 10);
        if (tile >= 0 && tile < 3) {
            type = tileType.NORMAL;
            SpawnTile = normalTile;
        } else if (tile >= 3 && tile < 6) {
            type = tileType.ENEMY;
            SpawnTile = enemyTile;
        } else if (tile >= 6 && tile < 8) {
            type = tileType.RACING;
            SpawnTile = racingTile;
        } else if (tile == 8) {
            type = tileType.NO_STATIC;
            SpawnTile = noTile;
        } else if (tile == 9) {
            type = tileType.NO_DYNAMIC;
            SpawnTile = noTile;
        }   
    }
}
