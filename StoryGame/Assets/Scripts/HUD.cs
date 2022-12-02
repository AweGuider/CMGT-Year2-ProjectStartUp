using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Story story;
    [SerializeField] private GameObject storyObj;

    [SerializeField] private LevelButton backButton;
    [SerializeField] private GameObject backButtonObj;
    [SerializeField] private Timer timer;
    [SerializeField] private Popup popup;
    [SerializeField] private GameObject optionGroup;
    [SerializeField] private List<GameObject> options;

    // Start is called before the first frame update
    void Start()
    {
        if (storyObj != null)
        {
            story = storyObj.GetComponent<Story>();
        }

        if (backButtonObj != null)
        {
            backButton = backButtonObj.GetComponent<LevelButton>();
        }

        for (int i = 0; i < optionGroup.transform.childCount; i++)
        {
            options.Add(optionGroup.transform.GetChild(i).gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerPopupUpdate();
    }

    private void TimerPopupUpdate()
    {
        if (timer.IsTimerDone())
        {
            if (!popup.IsStarted())
            {
                popup.StartTimer();
            }
            if (popup.CanSwitchPictures())
            {
                popup.showPictures();
            }
        }
    }
}
