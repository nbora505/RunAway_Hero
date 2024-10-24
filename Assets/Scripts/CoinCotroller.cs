using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCotroller : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject coinEffect;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreMgr").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            scoreManager.coin++;
            StartCoroutine(PlayCoinEffect());
        }
    }

    IEnumerator PlayCoinEffect()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Collider>().enabled = false;

        GameObject CoinLight = Instantiate<GameObject>(coinEffect, transform);
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
