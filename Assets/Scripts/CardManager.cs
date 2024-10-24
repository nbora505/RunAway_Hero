using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public CharacterManager characterMgr;
    public Text cardName;

    public int cardNum;


    void Start()
    {
        characterMgr = GameObject.Find("CharacterMgr").GetComponent<CharacterManager>();
        

        if (characterMgr._characters[cardNum] == 0)
        {
            cardName.text = "???";
            cardName.color = Color.black;
            transform.GetComponent<Button>().enabled = false;
            transform.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            cardName.text = characterMgr.characterName[cardNum];
            cardName.color = Color.white;
        }
    }

    void Update()
    {
        if(characterMgr._characters[cardNum] == 1)
        {
            transform.GetComponent<Button>().enabled = true;
            transform.GetComponent<Image>().color = Color.white;
            cardName.text = characterMgr.characterName[cardNum];
            cardName.color = Color.white;
        }
    }
}
