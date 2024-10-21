using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    static CharacterManager _instance;

    public static CharacterManager Instance()
    {
        return _instance;
    }

    public int[] _characters = new int[14];
    public int _curChar;

    public GameObject win_Gacha;
    public GameObject result;

    public int characterCnt;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }

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

    public void Gacha()
    {
        int rand = Random.Range(0, 14);
        _characters[rand] = 1;
        SaveCharacter();

        StartCoroutine(GachaEffect(rand));
    }

    public IEnumerator GachaEffect(int rand)
    {
        win_Gacha.SetActive(true);
        yield return new WaitForSeconds(3f);

        result.SetActive(true);
        Debug.Log(rand+"¹ø Ä³¸¯ÅÍ È¹µæ!!");
    }
}
