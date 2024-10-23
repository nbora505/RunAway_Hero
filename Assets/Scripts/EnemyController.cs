using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMaker enemyMaker;
    public float enemySpd;
    public int enemyType;
    public int tileType;
    public int enemyDir;

    public Transform[] floorX;

    void Start()
    {
        enemyMaker = GetComponentInParent<EnemyMaker>();
        enemySpd = enemyMaker.enemySpd;
        enemyType = enemyMaker.enemyType;
        tileType = enemyMaker.tileType;
        enemyDir = enemyMaker.enemyDir;

        if(tileType == 4)
        {
            if (enemyType >= 0 && enemyType < 2) enemyType = 1;
            else if (enemyType >= 2 && enemyType < 5) enemyType = 2;
            else if (enemyType >= 5 && enemyType < 10) enemyType = 3;

            floorX = GetComponentsInChildren<Transform>();
        }

    }

    void Update()
    {
        if (enemyDir == 0) 
        {
            transform.Translate(enemySpd * Time.deltaTime, 0, 0);
        }
        else if (enemyDir == 1)
        {
            transform.Translate(-enemySpd * Time.deltaTime, 0, 0);
        }
    }

}
