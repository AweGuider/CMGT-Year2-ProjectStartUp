using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timerButton;
    [SerializeField] private float timeMax;
    [SerializeField] private float timeRemaining;
    [SerializeField] private bool timerRunning;
    [SerializeField] private bool timerDone;
    [SerializeField] private bool useMinutes;
    [SerializeField] private HUD hud;

    public bool IsTimerDone()
    {
        return timerDone;
    }

    public void SetTimerDone(bool b)
    {
        timerDone = b;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (hud == null)
        {
            hud = transform.parent.GetComponent<HUD>();
        }

        if (timerButton == null)
        {
            timerButton = transform.GetChild(0).gameObject;
        }

        if (timerText == null)
        {
            timerText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            
        }
        timerText.gameObject.SetActive(false);
        gameObject.SetActive(false);

        useMinutes = !GameData.devMode;

        if (useMinutes)
        {
            if (timeRemaining == 0)
            {
                timeRemaining = 120;
            }
            timeRemaining *= 60;
        }
        else
        {
            if (timeRemaining == 0)
            {
                timeRemaining = 120;
            }
        }
        timeMax = timeRemaining;

    }

    // Update is called once per frame
    void Update()
    {
        TimerCountdown();

    }

    public void StartTimer()
    {
        if (timeRemaining > 0)
        {
            hud.SetStoryActive(false);
            timerRunning = true;
            timerText.gameObject.SetActive(true);
        }
    }

    public void ResetTimer()
    {
        gameObject.SetActive(true);
        timeRemaining = timeMax;
    }

    private void TimerCountdown()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0;
                timerText.gameObject.SetActive(false);
                gameObject.SetActive(false);
                timerDone = true;
                Debug.Log("Time has run out!");

            }

        }
    }
}
