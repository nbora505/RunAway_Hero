using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public bool[] characters = new bool[14];

    public GameObject win_Gacha;
    public GameObject result;

    void Start()
    {
        characters[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gacha()
    {
        int rand = Random.Range(0, 14);
        characters[rand] = true;

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
