using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DailyButton : MonoBehaviour
{
    public Button targetButton;
    public Text timerText;

    private DateTime nextActiveTime;
    private bool isButtonActive;

    public GameObject win_Shop;
    public Image[] presentImage = new Image[3];

    void Start()
    {
        if (PlayerPrefs.HasKey("LastActiveTime"))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString("LastActiveTime"));
            DateTime lastActiveTime = DateTime.FromBinary(temp);
            nextActiveTime = lastActiveTime.AddHours(24);
        }
        else
        {
            nextActiveTime = DateTime.Now;
        }

        UpdateButtonState();
    }

    void Update()
    {
        if (!isButtonActive)
        {
            UpdateButtonState();
            UpdateTimerText();
        }
    }

    private void UpdateButtonState()
    {
        if (DateTime.Now >= nextActiveTime)
        {
            targetButton.interactable = true;
            isButtonActive = true;
            timerText.text = "¿œ¿œ º±π∞ »πµÊ!";
            presentImage[0].color = Color.gray;
            presentImage[1].color = Color.gray;
            presentImage[2].color = Color.white;
        }
        else
        {
            targetButton.interactable = false;
            isButtonActive = false;
            for (int i = 0; i < 3; i++) presentImage[i].color = Color.black;
        }
    }

    private void UpdateTimerText()
    {
        if (!isButtonActive)
        {
            TimeSpan remainingTime = nextActiveTime - DateTime.Now;
            timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);
        }
    }

    public void OnButtonClick()
    {
        win_Shop.GetComponent<Win_Shop>().GetCoinToPresent();

        nextActiveTime = DateTime.Now.AddHours(24);
        PlayerPrefs.SetString("LastActiveTime", nextActiveTime.ToBinary().ToString());
        PlayerPrefs.Save();

        UpdateButtonState();
    }
}
