using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using static System.Math;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;

public class DynamicMoving : MonoBehaviour
{
    public PlayerController playerController;
    public CameraMoving cameraMoving;
    public EnemyController enemyController;
    public GameOverManager gameOverManager;

    void Start()
    {   
        gameOverManager = GameObject.Find("GameOverMgr").GetComponent<GameOverManager>();

        if(!gameOverManager.GetComponent<GameOverManager>().isDead)
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        cameraMoving = GameObject.Find("Camera").GetComponent<CameraMoving>();
        enemyController = GetComponentInParent<EnemyController>();
    }

    
    void Update()
    {

    }

    private void OnCollisionStay(Collision coll)
    {
        if (coll.collider.tag == "Player")
        {
            //Debug.Log("Ãæµ¹!");
            playerController.isOnFloor = true;
            playerController.currentX = transform.position.x;
            cameraMoving.currentX = transform.position.x;

        }
    }
    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.tag == "Player")
        {
            float round = Mathf.Round(transform.position.x);
            Debug.Log(round);
            playerController.currentX = round;
            cameraMoving.currentX = round;

            playerController.isOnFloor = false;
        }
    }
}
