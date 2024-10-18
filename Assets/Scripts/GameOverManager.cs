using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverPanel;
    public CameraMoving cameraMoving;
    public GameObject playerCharacter;
    public GameObject monster;

    public bool isDead;

    void Start()
    {
        cameraMoving = GameObject.Find("Camera").GetComponent<CameraMoving>();
    }

    public IEnumerator PlayerDeath(float delay)
    {
        isDead = true;

        yield return new WaitForSeconds(delay);
        //Æø¹ß ÀÌÆåÆ®
        Debug.Log("Æã!!!!!!!!");
        cameraMoving.speed = 0;
        GetComponent<GameManager>().gameStart = false;
        //playerCharacter.gameObject.transform.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(1f);

        gameOverPanel.SetActive(true);
        player.SetActive(false);

    }

    public IEnumerator TimeOutDeath(float delay)
    {
        isDead = true;

        yield return new WaitForSeconds(delay);
        //Æø¹ß ÀÌÆåÆ®
        Debug.Log("Æã!!!!!!!!");
        cameraMoving.speed = 0;
        GetComponent<GameManager>().gameStart = false;

        monster.transform.Translate(0, 0, 50f * Time.deltaTime);

        yield return new WaitForSeconds(1f);

        gameOverPanel.SetActive(true);
        player.SetActive(false);

    }


}
