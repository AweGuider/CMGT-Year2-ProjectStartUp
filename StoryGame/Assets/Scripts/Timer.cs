using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timerButton;
    [SerializeField] private GameObject timerImage;
    [SerializeField] private float timeMax;
    [SerializeField] private float timeRemaining;
    [SerializeField] private bool timerRunning;
    [SerializeField] private bool timerDone;
    [SerializeField] private bool useMinutes;

    public bool IsTimerDone()
    {
        return timerDone;
    }

    public void SetTimerDone(bool b)
    {
        timerDone = b;
    }

    private void Awake()
    {
        if (timerButton == null)
        {
            timerButton = transform.GetChild(0).gameObject;
        }

        if (timerText == null)
        {
            timerText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        }

        timerText.gameObject.SetActive(false);
        timerImage.SetActive(false);
        timerButton.SetActive(false);
    }

    void Start()
    {

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

    void Update()
    {
        TimerCountdown();
    }

    public void StartTimer()
    {
        if (timeRemaining > 0)
        {
            timerRunning = true;
        }
    }

    public void ResetTimer()
    {
        timerButton.SetActive(true);
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
                timerImage.SetActive(false);
                timerDone = true;
                Debug.Log("Time has run out!");

            }
        }
    }
}
