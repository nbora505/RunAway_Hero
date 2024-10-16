using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.UI.Image;

public class CameraMoving : MonoBehaviour
{
    public GameObject mainCamera;
    public bool isMoving = true;
    public bool isDone;

    public float speed = 0.1f;
    public float currentZ = 0;
    public float currentX = 0, originX;

    public PlayerController playerController;
    public DynamicMoving dynamicMoving;
    public GameManager gameManager;
    public GameOverManager gameOverManager;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameMgr").GetComponent<GameManager>();
        gameOverManager = GameObject.Find("GameMgr").GetComponent<GameOverManager>();
    }

    void Update()
    {
        if (gameManager.gameStart)
        {
            currentZ = transform.position.z;
            transform.position = new Vector3(currentX, 0, currentZ);

            if (isMoving)
            {
                MoveCamera();
            }
            else
            {
                ReturnCamera();
            }

            if(currentZ >= 3f)
            {
                Debug.Log("게임 오버!!!");
                StartCoroutine(gameOverManager.TimeOutDeath(0.1f));
            }
        }
    }

    public void MoveCamera()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (playerController.tileMoving == true)
        {
            isMoving = false;
            //플레이어(맵)이 1칸 이동을 5의 속도로 이동하므로, 죽이되든 밥이되든 똑같은 시간에 z=0까지 이동해야 함
            //거리 1, 속력 5, 시간 0.2
            //거리 z, 속력 speed, 시간 0.2
            speed = transform.position.z / 0.2f;
        }
    }

    public void ReturnCamera()
    {        
        transform.Translate(0, 0, -speed * Time.deltaTime);

        if (transform.position.z <= 0)
        {
            transform.position = new Vector3(currentX, 0, 0);
            isMoving = true;
            speed = 0.5f;
        }

    }
    public void MoveCameraLeft()
    {
        transform.Translate(-playerController.speed * Time.deltaTime, 0, 0);
        currentX = transform.position.x;

        if (currentX <= originX - 1)
        {
            currentX = originX - 1;
            transform.position = new Vector3(currentX, 0, currentZ);
            //isMoving = false;
        }
    }
    public void MoveCameraRight()
    {
        transform.Translate(playerController.speed * Time.deltaTime, 0, 0);
        currentX = transform.position.x;

        if (currentX >= originX + 1)
        {
            currentX = originX + 1;
            transform.position = new Vector3(currentX, 0, currentZ);
            //isMoving = false;
        }
    }
}
