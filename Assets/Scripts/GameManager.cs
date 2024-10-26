using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

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
    public GameObject optionPanel;
    public GameObject AD;

    public bool gameStart;
    public int panelState;

    public Slider cntBar;
    public Text scoreText;
    public Text topScoreText;
    public Text coinText;
    public Text characterCountText;
    public CharacterManager characterManager;
    public GameObject win_character;

    static GameManager _instance;
    public bool isMain = true;
    public AudioClip buttonSfx;

    public static GameManager Instance()
    {
        return _instance;
    }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        anim1 = startPanel.GetComponent<Animator>();
        anim2 = buttonPanel.GetComponent<Animator>();

        anim1.SetTrigger("sceneStart");

        CP = characterPanel.GetComponent<Animator>();
        SP = shopPanel.GetComponent<Animator>();

    }

    void Update()
    {
        scoreText.text = "" + ScoreManager.Instance().myScore;
        topScoreText.text = "TOP:" + ScoreManager.Instance().bestScore;
        coinText.text = "" + ScoreManager.Instance().coin;

        cntBar.value = (float)characterManager.characterCnt / 14;
        characterCountText.text = characterManager.characterCnt + " / 14";
    }

    public void OnOptionBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        optionPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnCloseOptionBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        optionPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnADBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        AD.SetActive(true);
    }
    public void OnCloseADBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        AD.SetActive(false);
        ScoreManager.Instance().GetCoinToAd();
    }

    public void OnGachaBackBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        win_gacha_result.SetActive(false);
        win_gacha.SetActive(false);
    }

    public void OnCharacterPanelBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        isMain = false;
        startPanel.SetActive(false);
        CP.SetTrigger("Appear");
        if(panelState != 0) SP.SetTrigger("Disappear");

        panelState = 1;
    }
    public void OnShopPanelBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        isMain = false;
        startPanel.SetActive(false);
        SP.SetTrigger("Appear");
        if (panelState != 0) CP.SetTrigger("Disappear");

        panelState = 2;
    }

    public void OnStartBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        anim1.SetTrigger("gameStart");
        anim2.SetTrigger("gameStart");
        StartCoroutine(WaitTime(0.5f));

        startPanel.SetActive(false);

        gameStart = true;
    }

    public void OnReStartBtn()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        startPanel.SetActive(false);
        startPanel.SetActive(true);
        anim1.SetTrigger("reStart");
        StartCoroutine(WaitBeforeLoadScene(1f));
    }
    public void CardSelect()
    {
        AudioManager.Instance().PlaySfx(buttonSfx);
        Win_Character win_Character = win_character.GetComponent<Win_Character>();
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        win_Character.curChar = int.Parse(clickObject.name);
        Debug.Log(win_Character.curChar);
        
        win_character.SetActive(true);
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
    public void OnExitBtn()
    {
        Application.Quit();
    }
}
