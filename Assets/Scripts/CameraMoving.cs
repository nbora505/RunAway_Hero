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

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
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
    }

    public void MoveCamera()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (playerController.tileMoving == true)
        {
            isMoving = false;
            //�÷��̾�(��)�� 1ĭ �̵��� 5�� �ӵ��� �̵��ϹǷ�, ���̵ǵ� ���̵ǵ� �Ȱ��� �ð��� z=0���� �̵��ؾ� ��
            //�Ÿ� 1, �ӷ� 5, �ð� 0.2
            //�Ÿ� z, �ӷ� speed, �ð� 0.2
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
