using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Shop : MonoBehaviour
{
    public ScoreManager scoreManager;

    public GameObject win_Present;
    public GameObject result;
    public GameObject cautionPanel;

    public Text coinText;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreMgr").GetComponent<ScoreManager>();
    }
    void Update()
    {
        coinText.text = scoreManager.coin + "c";
    }
    public void GetCoinToPresent()
    {
        int rand = Random.Range(40, 251);

        StartCoroutine(PresentEffect(rand));

    }
    public void OffCautionPanel()
    {
        cautionPanel.SetActive(false);
    }
    public IEnumerator PresentEffect(int rand)
    {
        win_Present.SetActive(true);
        yield return new WaitForSeconds(3f);

        scoreManager.coin += rand;
        result.SetActive(true);
        Debug.Log(rand + "°³ È¹µæ!!");
    }
    public void BackBtn()
    {
        result.SetActive(false);
        win_Present.SetActive(false);
    }
}
