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

        characterDescription[0] = "달리기가 특기인 시간의 영웅. 하지만 지금은 도망치는 것 밖에 할 수 있는 것이 없다!";
        characterDescription[1] = "사인참사검을 쓰는 청년 검객. 노란 옷의 왕은 이럴 때 도와주지 않고 뭐 하는 건지!";
        characterDescription[2] = "공간의 힘을 다루는 맹인 성녀. 를뤼에의 주인조차 게임 속에선 도망칠 수 밖에 없다.";
        characterDescription[3] = "네모나진 작고 사악한 과학자. 그녀를 지켜주던 동물 로봇들도 전부 사라져버렸다.";
        characterDescription[4] = "고결한 이단심문관 성기사. 유니콘 고르디우스가 없어진 탓에 뚜벅이 신세가 되었다.";
        characterDescription[5] = "세종시 참변의 유일한 생존자. 네모네모해진 이상 강력한 성녀의 힘은 더 이상 쓸 수 없다.";
        characterDescription[6] = "백야 클랜 최고의 문제아. 불꽃의 창 데이브레이커를 되찾기 위해서는 도망쳐야 한다!";
        characterDescription[7] = "황금룡의 힘을 가진 괴이 소년. 물론 네모난 세상 안에선 그런 거 없이 평등하게 무능하다.";
        characterDescription[8] = "프리메이슨의 일원인 영국 신사. 대영제국의 부활을 위해서라면 얼마든지 도망칠 수 있다.";
        characterDescription[9] = "카드 마술이 주특기인 마술사. 친구에게 넘겨받은 희망을 품고 멀리 달려나가기로 한다.";
        characterDescription[10] = "마검 홍련을 가진 검객 소녀. 그녀의 예술을 계속하기 위해서는 이곳에서 탈출해야 한다!";
        characterDescription[11] = "별의 영혼을 부르는 사막 왕자. 소꿉친구와 재회하기 전에 이런 곳에서 죽을 수는 없다.";
        characterDescription[12] = "아가씨가 되고싶은 격투가 소녀. 어째서인지 미래의 힘을 빌려오는 능력이 발동하지 않는다!";
        characterDescription[13] = "사지에 강철을 단 연금술사. 여기선 연성을 사용할 수 없다. 국가연성진의 끝까지 도망쳐라!";

    }
}
