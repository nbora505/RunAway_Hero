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
        characterName[0] = "������";
        characterName[1] = "�̼���";
        characterName[2] = "Ÿ��";
        characterName[3] = "ī����";
        characterName[4] = "�̹���";
        characterName[5] = "ǥ�̸�";
        characterName[6] = "���ټ�";
        characterName[7] = "�׿�";
        characterName[8] = "�ʷ���";
        characterName[9] = "Ŭ�����";
        characterName[10] = "���";
        characterName[11] = "��Ÿ�̸�";
        characterName[12] = "������";
        characterName[13] = "��Ʈ";

        characterDescription[0] = "�����δ�";
        characterDescription[1] = "�̼����̴�";
        characterDescription[2] = "Ÿ�Ĵ�";
        characterDescription[3] = "ī�����̴�";
        characterDescription[4] = "�̹��ִ�";
        characterDescription[5] = "ǥ�̸���";
        characterDescription[6] = "���ټ���";
        characterDescription[7] = "�׿���";
        characterDescription[8] = "�ʷ����̴�";
        characterDescription[9] = "Ŭ����ƴ�";
        characterDescription[10] = "��ƴ�";
        characterDescription[11] = "��Ÿ�̸���";
        characterDescription[12] = "��������";
        characterDescription[13] = "��Ʈ��";

    }
}
