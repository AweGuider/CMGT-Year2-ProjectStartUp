using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Story story;
    [SerializeField] private GameObject storyObj;

    [SerializeField] private LevelButton backButton;
    [SerializeField] private GameObject backButtonObj;
    [SerializeField] private Timer timer;
    [SerializeField] private Popup popup;
    [SerializeField] private bool showPopups;
    [SerializeField] private TextMeshProUGUI optionsText;
    [SerializeField] private GameObject optionGroup;
    [SerializeField] private List<GameObject> options;
    [SerializeField] private bool singleOption;

    private void Awake()
    {
        for (int i = 0; i < optionGroup.transform.childCount; i++)
        {
            options.Add(optionGroup.transform.GetChild(i).gameObject);
        }

        SetOptionsInactive();
    }

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
        backButtonObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.IsTimerDone())
        {
            timer.SetTimerDone(false);
            popup.showPictures();
        }

        if (popup.IsDone())
        {
            optionsText.gameObject.SetActive(true);
            if (singleOption)
            {
                SetSingleActive(true);
            }
            else
            {
                SetMultiActive(true);
            }
            popup.SetDone(false);
        }
    }

    public void SetOptionsInactive()
    {
        for (int i = 0; i < options.Count; i++)
        {
            {
                options[i].SetActive(false);
            }
        }
        optionsText.gameObject.SetActive(false);
    }

    private void SetSingleActive(bool b)
    {
        options[2].SetActive(b);
    }

    private void SetMultiActive(bool b)
    {
        options[0].SetActive(b);
        options[1].SetActive(b);
    }

    public void SetOptionsLink(string s)
    {
        string str = s.Replace("[", "").Replace("]", "");
        if (str.Contains("@"))
        {
            backButtonObj.SetActive(true);
            return;
        }
        if (str.Contains(','))
        {
            singleOption = false;
            var o = str.Split(",");
            options[int.Parse(o[0]) - 1].GetComponent<Option>().SetLink(o[1]);
            //Debug.Log(string.Format("Option message: {0}, number: {1}", o, options.IndexOf(o)));
        }
        else
        {
            singleOption = true;
            options[2].GetComponent<Option>().SetLink(str);

        }
    }

    public void SetOptionsText(string s)
    {
        string str = s.Replace("{", "").Replace("}", "");

        if (str.Contains(','))
        {
            singleOption = false;
            var o = str.Split(",");

            options[int.Parse(o[0]) - 1].GetComponent<Option>().SetText(o[1]);
            //Debug.Log(string.Format("Option message: {0}, number: {1}", o, options.IndexOf(o)));
            //Debug.Log(string.Format("Option left: {0}, length: {1}, option right: {2}, length: {3}",
            //    o[0], o[0].Length, o[1], o[1].Length));
        }
        else
        {
            singleOption = true;
            options[2].GetComponent<Option>().SetText(str);
        }
    }

    public void ChangeStoryPath(string path)
    {
        SetStoryActive(true);
        Debug.Log(string.Format("Path: {0}, length: {1}", GameData.ConvertToHex(path), path.Length));

        story.LoadText(path);
    }

    public void ResetTimer()
    {
        timer.ResetTimer();
    }

    public void SetStoryActive(bool b)
    {
        story.gameObject.SetActive(b);
    }

    private void TimerPopupUpdate()
    {

        //if (timer.IsTimerDone())
        //{
        //    if (!popup.IsStarted())
        //    {
        //        popup.StartTimer();
        //    }
        //    if (popup.CanSwitchPictures())
        //    {
        //        popup.showPictures();
        //    }
        //}
    }
}
