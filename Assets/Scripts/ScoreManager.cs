using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;

    public static ScoreManager Instance()
    {
        return _instance;
    }

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        LoadBestScore();
        LoadCoin();
    }

    int _bestScore = 0;
    int _myScore = 0;
    int _coin = 0;

    public int coin
    {
        get { return _coin; }
        set
        {
            _coin = value;
            SaveCoin();
        }
    }

    public int bestScore
    {
        get { return _bestScore; }
    }
    public int myScore
    {
        get { return _myScore; }
        set
        {
            _myScore = value;
            if (_myScore > _bestScore)
            {
                _bestScore = _myScore;
                SaveBestScore();
                Debug.Log("최고점수 갱신 ::: " + _bestScore);
            }
        }
    }
    void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", _coin);
    }
    void LoadCoin()
    {
        _coin = PlayerPrefs.GetInt("Coin");
    }
    void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", _bestScore);
    }
    void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore");
    }
}
