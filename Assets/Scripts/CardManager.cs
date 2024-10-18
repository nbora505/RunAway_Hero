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

        if (characterMgr.characters[cardNum] == false)
        {
            transform.GetComponent<Button>().enabled = false;
            transform.GetComponent<Image>().color = Color.gray;
        }
    }

    void Update()
    {
        if(characterMgr.characters[cardNum] == true)
        {
            transform.GetComponent<Button>().enabled = true;
            transform.GetComponent<Image>().color = Color.white;
        }
    }
}
