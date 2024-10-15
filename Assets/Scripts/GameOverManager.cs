using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverPanel;
    public CameraMoving cameraMoving;

    void Start()
    {
        cameraMoving = GameObject.Find("Camera").GetComponent<CameraMoving>();
    }

    void Update()
    {
        
    }

    public IEnumerator PlayerDeath(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.SetActive(false);
        cameraMoving.speed = 0;

        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);

    }
}
