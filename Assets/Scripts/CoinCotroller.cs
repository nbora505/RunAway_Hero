using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCotroller : MonoBehaviour
{
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreMgr").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            scoreManager.coin++;
            Destroy(gameObject);
        }
    }
}
