using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    static CharacterManager _instance;
    public ScoreManager scoreManager;

    public static CharacterManager Instance()
    {
        return _instance;
    }

    public int[] _characters = new int[14];
    public int _curChar;

    public GameObject win_Gacha;
    public GameObject result;

    public int characterCnt;

    public GameManager gameMgr;
    public GameObject cautionPanel;

    public string filePath;
    public List<Dictionary<string, object>> data;
    public string[] characterName = new string[14];
    public string[] characterDescription = new string[14];

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        SetCharacterList();

        LoadCharacter();
        LoadCurChar();
        _characters[0] = 1;
    }

    void Update()
    {
        characterCnt = 0;
        for (int i = 0; i < 14; i++)
        {
            if (_characters[i] == 1) characterCnt++;
        }
    }

    public int[] chacracters
    {
        get { return _characters; }
        set
        {
            _characters = value;
            SaveCharacter();
        }
    }
    public int curChar
    {
        get { return _curChar; }
        set
        {
            _curChar = value;
            SaveCurChar();
        }
    }

    void SaveCharacter()
    {
        for (int i = 0; i < _characters.Length; i++)
        {
            PlayerPrefs.SetInt("Character" + i, _characters[i]);
        }
        PlayerPrefs.Save();
    }

    void LoadCharacter()
    {
        for (int i = 0; i < _characters.Length; i++)
        {
            _characters[i] = PlayerPrefs.GetInt("Character" + i);
        }
    }
    void SaveCurChar()
    {
        PlayerPrefs.SetInt("CurrentChararacter", _curChar);
    }
    void LoadCurChar()
    {
        _curChar = PlayerPrefs.GetInt("CurrentChararacter");
    }

    public void RandomSelect()
    {
        int rand = Random.Range(0, 14);
        if (_characters[rand] == 0) RandomSelect();
        else
        {
            Debug.Log(rand);
            curChar = rand;
            gameMgr.OnReStartBtn();
        }
    }

    public void Gacha()
    {
        if (scoreManager.coin >= 100)
        {
            int rand = Random.Range(0, 14);
            _characters[rand] = 1;
            SaveCharacter();

            scoreManager.coin -= 100;

            StartCoroutine(GachaEffect(rand));
        }
        else
        {
            cautionPanel.SetActive(true);
        }
    }

    public IEnumerator GachaEffect(int rand)
    {
        win_Gacha.SetActive(true);
        yield return new WaitForSeconds(3f);

        result.SetActive(true);
        Debug.Log(rand+"번 캐릭터 획득!!");
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
