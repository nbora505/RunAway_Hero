using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public GameObject startPanel;
    public GameObject buttonPanel;
    public GameObject titleImage;

    public bool gameStart;

    void Start()
    {
        anim1 = startPanel.GetComponent<Animator>();
        anim2 = buttonPanel.GetComponent<Animator>();
        anim3 = titleImage.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void OnStartBtn()
    {
        anim3.SetTrigger("gameStart");
        anim2.SetTrigger("gameStart");
        StartCoroutine(Wait(0.5f));

        startPanel.SetActive(false);

        gameStart = true;
    }

    public void OnReStartBtn()
    {
        SceneManager.LoadScene("MainGame");
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
