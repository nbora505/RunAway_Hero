using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Win_Shop win_Shop;
    Text coinText;

    void Start()
    {
        coinText = GetComponent<Text>();
        coinText.text = win_Shop.getCoin + "c";    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
