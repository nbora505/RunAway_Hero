using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverPanel;
    public CameraMoving cameraMoving;
    public PlayerController playerController;
    public GameObject monster;
    public GameObject gameOverEffect;
    public GameObject gameOverEffect2;

    public AudioClip deadSfx1;
    public AudioClip deadSfx2;
    public AudioClip gameOverSfx;

    public bool isDead;
    int i,j,k;
    GameObject Dragon;

    void Start()
    {
        cameraMoving = GameObject.Find("Camera").GetComponent<CameraMoving>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    public IEnumerator PlayerDeath(float delay)
    {
        isDead = true;

        yield return new WaitForSeconds(delay);
        //Æø¹ß ÀÌÆåÆ®
        if (j == 0) AudioManager.Instance().PlaySfx(deadSfx1); j++;
        GameObject Spark = Instantiate<GameObject>(gameOverEffect, player.transform);
        cameraMoving.speed = 0;
        GetComponent<GameManager>().gameStart = false;
        playerController.playerCharacter.SetActive(false);

        yield return new WaitForSeconds(1f);

        gameOverPanel.SetActive(true);
        player.SetActive(false);
        if(k == 0) AudioManager.Instance().PlaySfx(gameOverSfx); k++;
    }

    public IEnumerator TimeOutDeath(float delay)
    {
        isDead = true;

        if (i == 0) Dragon = Instantiate<GameObject>(monster, new Vector3(player.transform.position.x, 0, -2), Quaternion.identity);
        Animator monsterAppear = GameObject.Find("TimeOutMonster(Clone)").GetComponentInChildren<Animator>();
        i++;

        Dragon.transform.Translate(0, 0, 10f * Time.deltaTime);
        monsterAppear.SetTrigger("PlayerDead");

        yield return new WaitForSeconds(delay);
        cameraMoving.speed = 0;
        GetComponent<GameManager>().gameStart = false;

        GameObject Explosion = Instantiate<GameObject>(gameOverEffect2, new Vector3(player.transform.position.x, 0, 0), Quaternion.identity);
        if(j == 0) AudioManager.Instance().PlaySfx(deadSfx2); j++;

        yield return new WaitForSeconds(1f);

        gameOverPanel.SetActive(true);
        player.SetActive(false);
        if (k == 0) AudioManager.Instance().PlaySfx(gameOverSfx); k++;
        //AudioManager.Instance().GetComponent<AudioSource>().volume -= 0.1f;
    }


}
