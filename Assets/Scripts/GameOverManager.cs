using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverPanel;
    public CameraMoving cameraMoving;

    public bool isDead;

    void Start()
    {
        cameraMoving = GameObject.Find("Camera").GetComponent<CameraMoving>();
    }

    void Update()
    {
        
    }

    public IEnumerator PlayerDeath(float delay)
    {
        isDead = true;

        yield return new WaitForSeconds(delay);
        player.SetActive(false); //이거 수정 바람
        cameraMoving.speed = 0;

        yield return new WaitForSeconds(0.1f);
        Debug.Log("돼는디?");
        gameOverPanel.SetActive(true);

    }
}
