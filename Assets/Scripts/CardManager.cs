using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public CharacterManager characterMgr;
    public int cardNum;


    void Start()
    {
        characterMgr = GameObject.Find("CharacterMgr").GetComponent<CharacterManager>();

        if (characterMgr._characters[cardNum] == 0)
        {
            transform.GetComponent<Button>().enabled = false;
            transform.GetComponent<Image>().color = Color.gray;
        }
    }

    void Update()
    {
        if(characterMgr._characters[cardNum] == 1)
        {
            transform.GetComponent<Button>().enabled = true;
            transform.GetComponent<Image>().color = Color.white;
        }
    }
}
