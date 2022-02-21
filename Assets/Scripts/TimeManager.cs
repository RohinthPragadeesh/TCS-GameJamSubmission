using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float timeLeft = 10;
    [SerializeField] bool isTimerRunning;
    [SerializeField] TMP_Text timeDisplayText;
    [SerializeField] GameManager manager;

    public void OnStartGame()
    {
        timeLeft = 35;
        isTimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                DisplayTimeText(timeLeft);
            }
            else
            {
                manager.OnGameOver();
                timeLeft = 0;
                isTimerRunning = false;
            }
        }
    }

    public void DisplayTimeText(float time)
    {
        time += 1;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeDisplayText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

    public void AddExtraTime()
    {
        timeLeft += 10f;
    }

}
