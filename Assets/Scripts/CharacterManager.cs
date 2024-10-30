using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject win_Character;
    public GameObject result;

    public int characterCnt;

    public GameManager gameMgr;
    public GameObject cautionPanel;

    public string filePath;
    public List<Dictionary<string, object>> data;
    public string[] characterName = new string[14];
    public string[] characterDescription = new string[14];
    public Sprite[] characterSprite = new Sprite[14];
    public Image gachaResult;

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
        gachaResult.sprite = characterSprite[rand];
        Debug.Log(rand+"�� ĳ���� ȹ��!!");
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

        characterDescription[0] = "�޸��Ⱑ Ư���� �ð��� ����. ������ ������ ����ġ�� �� �ۿ� �� �� �ִ� ���� ����!";
        characterDescription[1] = "����������� ���� û�� �˰�. ��� ���� ���� �̷� �� �������� �ʰ� �� �ϴ� ����!";
        characterDescription[2] = "������ ���� �ٷ�� ���� ����. ������ �������� ���� �ӿ��� ����ĥ �� �ۿ� ����.";
        characterDescription[3] = "�׸��� �۰� ����� ������. �׳ฦ �����ִ� ���� �κ��鵵 ���� ��������ȴ�.";
        characterDescription[4] = "����� �̴ܽɹ��� �����. ������ ����콺�� ������ ſ�� �ѹ��� �ż��� �Ǿ���.";
        characterDescription[5] = "������ ������ ������ ������. �׸�׸����� �̻� ������ ������ ���� �� �̻� �� �� ����.";
        characterDescription[6] = "��� Ŭ�� �ְ��� ������. �Ҳ��� â ���̺극��Ŀ�� ��ã�� ���ؼ��� �����ľ� �Ѵ�!";
        characterDescription[7] = "Ȳ�ݷ��� ���� ���� ���� �ҳ�. ���� �׸� ���� �ȿ��� �׷� �� ���� ����ϰ� �����ϴ�.";
        characterDescription[8] = "�������̽��� �Ͽ��� ���� �Ż�. �뿵������ ��Ȱ�� ���ؼ���� �󸶵��� ����ĥ �� �ִ�.";
        characterDescription[9] = "ī�� ������ ��Ư���� ������. ģ������ �Ѱܹ��� ����� ǰ�� �ָ� �޷�������� �Ѵ�.";
        characterDescription[10] = "���� ȫ���� ���� �˰� �ҳ�. �׳��� ������ ����ϱ� ���ؼ��� �̰����� Ż���ؾ� �Ѵ�!";
        characterDescription[11] = "���� ��ȥ�� �θ��� �縷 ����. �Ҳ�ģ���� ��ȸ�ϱ� ���� �̷� ������ ���� ���� ����.";
        characterDescription[12] = "�ư����� �ǰ���� ������ �ҳ�. ��°������ �̷��� ���� �������� �ɷ��� �ߵ����� �ʴ´�!";
        characterDescription[13] = "������ ��ö�� �� ���ݼ���. ���⼱ ������ ����� �� ����. ������������ ������ �����Ķ�!";

    }
}
