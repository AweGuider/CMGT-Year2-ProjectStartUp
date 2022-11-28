using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private Story story;
    [SerializeField] private string _name;
    [SerializeField] private TextMeshProUGUI optionText;

    // Start is called before the first frame update
    void Start()
    {
        if (story == null)
        {
            story = gameObject.transform.parent.GetComponent<Story>();
        }
        _name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseOption()
    {
        if (name.Length > 0)
        {
            story.Continue(_name);
            //story.SetStory(name);
        }
    }
}
