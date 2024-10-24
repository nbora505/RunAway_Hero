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
        for (int i = 0; i < characterName.Length; i++)
        {
            characterName[i] = characterMgr.characterName[i];
            characterDescription[i] = characterMgr.characterDescription[i];
        }
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
}
