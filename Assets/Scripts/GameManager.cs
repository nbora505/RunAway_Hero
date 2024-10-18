using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;

    public Animator CP;
    public Animator SP;

    public GameObject startPanel;
    public GameObject buttonPanel;
    public GameObject titleImage;
    public GameObject characterPanel;
    public GameObject shopPanel;
    public GameObject win_gacha;
    public GameObject win_gacha_result;

    public bool gameStart;
    public int panelState;

    void Start()
    {
        anim1 = startPanel.GetComponent<Animator>();
        anim2 = buttonPanel.GetComponent<Animator>();

        anim1.SetTrigger("sceneStart");

        CP = characterPanel.GetComponent<Animator>();
        SP = shopPanel.GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void OnGachaBackBtn()
    {
        win_gacha_result.SetActive(false);
        win_gacha.SetActive(false);
    }

    public void OnCharacterPanelBtn()
    {
        startPanel.SetActive(false);
        CP.SetTrigger("Appear");
        if(panelState != 0) SP.SetTrigger("Disappear");

        panelState = 1;
    }
    public void OnShopPanelBtn()
    {
        startPanel.SetActive(false);
        SP.SetTrigger("Appear");
        if (panelState != 0) CP.SetTrigger("Disappear");

        panelState = 2;
    }

    public void OnStartBtn()
    {
        anim1.SetTrigger("gameStart");
        anim2.SetTrigger("gameStart");
        StartCoroutine(WaitTime(0.5f));

        startPanel.SetActive(false);

        gameStart = true;
    }

    public void OnReStartBtn()
    {
        startPanel.SetActive(false);
        startPanel.SetActive(true);
        anim1.SetTrigger("reStart");
        StartCoroutine(WaitBeforeLoadScene(1f));
    }

    IEnumerator WaitBeforeLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("대기");

        SceneManager.LoadScene("MainGame");
    }
    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("대기");
    }
}
