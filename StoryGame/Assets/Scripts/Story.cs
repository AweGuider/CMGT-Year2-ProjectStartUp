using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class Story : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private List<string> text;
    [SerializeField] private int lineIndex;
    [SerializeField] private bool showText;
    [SerializeField] private List<Option> options;
    [SerializeField] private TextMeshProUGUI outputText;

    // Start is called before the first frame update
    void Start()
    {
        options = new List<Option>();
        level = LevelSelect.selectedLevel;
        //some statement
        if (true) 
        {
            text = ReadStringToList(level);
            outputText.text = text[0];
            lineIndex = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenTexts();
    }

    private void MoveBetweenTexts()
    {
        
    }

    //public void 

    private List<string> ReadStringToList(int path)
    {
        if (path == 0) return new List<string>();
        string file = "Assets/Stories/Chapter " + path + ".txt";
        //Read the text from directly from the test.txt file
        var lines = File.ReadAllLines(file);
        foreach (string s in text)
        {
            Debug.Log(s);
        }
        //Debug.Log(lines);
        return new List<string>(lines);
    }

    public void Continue()
    {
        if (options == null || options.Count == 0)
        {
            ContinueNoOptions();
        }
        else
        {
            //Check what are the options, etc
        }
    }

    private void ContinueOptions()
    {

    }

    private void ContinueNoOptions()
    {
        Debug.Log("NO OPTIONS, JUST CONTINUE");
    }
}
