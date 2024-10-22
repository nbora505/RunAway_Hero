using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_Character : MonoBehaviour
{
    public CharacterManager characterMgr;
    public GameManager gameMgr;
    public string[] characterName = new string[14];
    public string[] characterDescription = new string[14];

    public Text cName;
    public Text cDescription;

    public int curChar;

    public GameObject win_character;

    void Start()
    {
        characterMgr = GameObject.Find("CharacterMgr").GetComponent<CharacterManager>();
        gameMgr = GameObject.Find("GameMgr").GetComponent<GameManager>();
        SetCharacterList();
    }

    void Update()
    {
        cName.text = characterName[curChar];
        cDescription.text = characterDescription[curChar];
    }
    public void OnCharacterSelectBtn()
    {
        Win_Character win_Character = GetComponent<Win_Character>();
        characterMgr.curChar = win_Character.curChar;
        Debug.Log(characterMgr.curChar);

        gameMgr.OnReStartBtn();

}
    public void RBtn()
    {
        curChar++;
        if (curChar < 14)
        {
            if (characterMgr._characters[curChar] == 1)
            {
                cName.text = characterName[curChar];
                cDescription.text = characterDescription[curChar];
            }
            else
            {
                RBtn();
            }
        }
        else
        {
            curChar = 0;
            cName.text = characterName[curChar];
            cDescription.text = characterDescription[curChar];
        }
    }

    public void LBtn()
    {
        curChar--;
        if (curChar >= 0)
        {
            if (characterMgr._characters[curChar] == 1)
            {
                cName.text = characterName[curChar];
                cDescription.text = characterDescription[curChar];
            }
            else
            {
                LBtn();
            }
        }
        else curChar = 0;
    }
    public void OnBackBtn()
    {
        win_character.SetActive(false);
    }
    void SetCharacterList()
    {
        characterName[0] = "서히로";
        characterName[1] = "이수혁";
        characterName[2] = "타냐";
        characterName[3] = "카르멘";
        characterName[4] = "이미주";
        characterName[5] = "표미르";
        characterName[6] = "곽다수";
        characterName[7] = "테오";
        characterName[8] = "필레몬";
        characterName[9] = "클라우디아";
        characterName[10] = "노아";
        characterName[11] = "알타이르";
        characterName[12] = "세레스";
        characterName[13] = "랑트";

        characterDescription[0] = "서히로다";
        characterDescription[1] = "이수혁이다";
        characterDescription[2] = "타냐다";
        characterDescription[3] = "카르멘이다";
        characterDescription[4] = "이미주다";
        characterDescription[5] = "표미르다";
        characterDescription[6] = "곽다수다";
        characterDescription[7] = "테오다";
        characterDescription[8] = "필레몬이다";
        characterDescription[9] = "클라우디아다";
        characterDescription[10] = "노아다";
        characterDescription[11] = "알타이르다";
        characterDescription[12] = "세레스다";
        characterDescription[13] = "랑트다";

    }
}
