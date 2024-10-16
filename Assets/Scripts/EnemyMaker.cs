using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMaker : MonoBehaviour
{
    public int makerPos;

    public GameObject enemyPrefab;
    public GameObject enemy;
    public GameObject warning;

    public int[] enemyPos = new int[4];
    public int enemyCnt;
    public int enemyType;

    public int enemyDir;
    public float enemySpd;
    public float enemyCool;
    public float curTime;
    float miniCurTime;

    public TileMaker tileMaker;
    public int tileType;

    void Awake()
    {

        tileMaker = GameObject.Find("TileMaker").GetComponent<TileMaker>();
        tileType = (int)tileMaker.type;

        if (tileType == 0 || tileType == 3)
        {
            SetEnemyCnt();
            SetEnemyPos();
            for (int i = 0; i < enemyCnt; i++)
            {
                SetEnemyType();
                if (tileType == 0)
                    enemy = Instantiate(enemyPrefab, new Vector3(enemyPos[i], 0, transform.position.z), Quaternion.identity, transform);
                else if (tileType == 3)
                    enemy = Instantiate(enemyPrefab, new Vector3(enemyPos[i], -1, transform.position.z), Quaternion.identity, transform);
                enemy.transform.parent = null;
                enemy.transform.localScale = new Vector3(1f, 1f, 1f);
                enemy.transform.parent = this.transform;
            }
        }
        else if(tileType == 1 || tileType == 4)
        {
            SetEnemyDir();
            SetEnemySpd();
            SetEnemyCool();

            SetEnemyType();
            if (tileType == 1)
                enemy = Instantiate(enemyPrefab, new Vector3(makerPos, 0, transform.position.z), Quaternion.identity, transform);
            else if (tileType == 4)
                enemy = Instantiate(enemyPrefab, new Vector3(makerPos, -1, transform.position.z), Quaternion.identity, transform);
            enemy.transform.parent = null;
            enemy.transform.localScale = new Vector3(1f, 1f, 1f);
            enemy.transform.parent = this.transform;
        }
        else
        {
            SetEnemyDir();
            SetEnemySpd();
            SetEnemyCool();
        }
        
    }
    
    void Update()
    {
        curTime += Time.deltaTime;
        if (tileType == 1 || tileType == 4)
        {
            if (curTime > enemyCool)
            {
                curTime = 0;
                SetEnemyType();
                if (tileType == 1)
                    enemy = Instantiate(enemyPrefab, new Vector3(makerPos, 0, transform.position.z), Quaternion.identity, transform);
                else if (tileType == 4)
                    enemy = Instantiate(enemyPrefab, new Vector3(makerPos, -1, transform.position.z), Quaternion.identity, transform);
                enemy.transform.parent = null;
                enemy.transform.localScale = new Vector3(1f, 1f, 1f);
                enemy.transform.parent = this.transform;
            }
        }
        if(tileType == 2)
        {
            if (curTime >= 10f && curTime < 11f)
            {
                //°æ°í
                warning.SetActive(true);
            }

            if (curTime >= 11f && curTime < 12f)
            {
                warning.SetActive(false);

                miniCurTime += Time.deltaTime;
                if (miniCurTime > enemyCool)
                {
                    miniCurTime = 0;
                    SetEnemyType();
                    enemy = Instantiate(enemyPrefab, new Vector3(makerPos, 0, transform.position.z), Quaternion.identity, transform);
                    enemy.transform.parent = null;
                    enemy.transform.localScale = new Vector3(1f, 1f, 1f);
                    enemy.transform.parent = this.transform;
                }
            } else if (curTime >= 12f) curTime = 0;
        }
    }

    public void SetEnemyCnt()
    {
        enemyCnt = Random.Range(0, 10);
        if (enemyCnt == 0) enemyCnt = 4;
        else if (enemyCnt >= 1 && enemyCnt < 3) enemyCnt = 3;
        else if (enemyCnt >= 3 && enemyCnt < 7) enemyCnt = 2;
        else if (enemyCnt >= 7 && enemyCnt < 10) enemyCnt = 1;
    }
    public void SetEnemyPos()
    {
        if (enemyPos.Length < enemyCnt)
        {
            enemyPos = new int[enemyCnt];
        }

        for (int i = 0; i < enemyCnt; i++)
        {
            enemyPos[i] = Random.Range(0, 9) - 4;
            if (tileType == 0 && enemyPos[i] == 0) i--;
            if (tileType == 3 && i == 0) enemyPos[i] = 0;

            for (int j = 0; j < i; j++)
                if (enemyPos[i] == enemyPos[j]) i--;     
        }
    }
    public void SetEnemyType()
    {
        switch (tileType)
        {
            case 0:
                enemyType = Random.Range(0, 4);

                if (enemyType == 0) enemyPrefab = Resources.Load("Prefabs/Enemy/Block1") as GameObject;
                else if (enemyType == 1) enemyPrefab = Resources.Load("Prefabs/Enemy/Block2") as GameObject;
                else if (enemyType == 2) enemyPrefab = Resources.Load("Prefabs/Enemy/Block3") as GameObject;
                else if (enemyType == 3) enemyPrefab = Resources.Load("Prefabs/Enemy/Block4") as GameObject;
                break;
            case 1:
                enemyType = Random.Range(0, 4);

                if (enemyType == 0) enemyPrefab = Resources.Load("Prefabs/Enemy/Ghost_Pink") as GameObject;
                else if (enemyType == 1) enemyPrefab = Resources.Load("Prefabs/Enemy/Ghost_Red") as GameObject;
                else if (enemyType == 2) enemyPrefab = Resources.Load("Prefabs/Enemy/Ghost_Yellow") as GameObject;
                else if (enemyType == 3) enemyPrefab = Resources.Load("Prefabs/Enemy/Ghost_Blue") as GameObject;
                break;
            case 2:
                enemyPrefab = Resources.Load("Prefabs/Enemy/RacingCar") as GameObject;
                break;
            case 3:
                enemyPrefab = Resources.Load("Prefabs/Enemy/Floor_Static") as GameObject;
                break;
            case 4:
                enemyType = Random.Range(0, 10);

                if (enemyType >= 0 && enemyType < 2) enemyPrefab = Resources.Load("Prefabs/Enemy/Floor_Dynamic1") as GameObject;
                else if (enemyType >= 2 && enemyType < 5) enemyPrefab = Resources.Load("Prefabs/Enemy/Floor_Dynamic2") as GameObject;
                else if (enemyType >= 5 && enemyType < 10) enemyPrefab = Resources.Load("Prefabs/Enemy/Floor_Dynamic3") as GameObject;
                break;
            default:
                break;
        }
    }
    public void SetEnemyDir()
    {
        enemyDir = Random.Range(0, 2);
        if (enemyDir == 0)
        {
            makerPos = -10;
        }else if (enemyDir == 1)
        {
            makerPos = 10;
        }
    }
    public void SetEnemySpd()
    {
        if(tileType == 2)
        {
            enemySpd = 30f;
        }
        else
        {
            enemySpd = Random.Range(0, 5);
            if (enemySpd == 0) enemySpd = 1f;
            else if (enemySpd == 1) enemySpd = 1.3f;
            else if (enemySpd == 2) enemySpd = 1.6f;
            else if (enemySpd == 3) enemySpd = 1.9f;
            else if (enemySpd == 4) enemySpd = 2.2f;
        }
    }
    public void SetEnemyCool()
    {
        if (tileType == 2)
        {
            enemyCool = 0.05f;
        }
        else
        {
            enemyCool = Random.Range(0, 5);
            if (enemyCool == 0) enemyCool = 3f;
            else if (enemyCool == 1) enemyCool = 3.5f;
            else if (enemyCool == 2) enemyCool = 4f;
            else if (enemyCool == 3) enemyCool = 4.5f;
            else if (enemyCool == 4) enemyCool = 5f;
        }
    }
}
