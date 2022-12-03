using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private Story story;
    [SerializeField] private HUD hud;
    [SerializeField] private string link;
    [SerializeField] private TextMeshProUGUI optionText;

    // Start is called before the first frame update
    void Start()
    {
        if (hud == null)
        {
            hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        }

        if (story == null)
        {
            story = gameObject.transform.parent.GetComponent<Story>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLink(string l)
    {
        if (l.Length > 0)
        {
            link = l;
            Debug.Log(string.Format("Link: {0}, length: {1}", link, link.Length));

        }
    }

    public void SetText(string t)
    {
        if (t.Length > 0)
        {
            optionText.text = t;
        }
    }

    public void ChooseOption()
    {
        if (link.Length > 0)
        {
            hud.SetOptionsInactive();

            hud.ChangeStoryPath(link);
        }
    }
}
