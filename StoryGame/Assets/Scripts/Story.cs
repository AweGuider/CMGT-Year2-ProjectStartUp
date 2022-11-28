using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    [Header("Text Animation")]
    [SerializeField] private float letterDelay;
    [SerializeField] private bool animatingText;

    //Might need for advanced/future implementations
    TextAnimation textAnimation;

    [Header("Text/Story related")]
    [SerializeField] private string path;
    [SerializeField] private int lineIndex;
    [SerializeField] private List<string> story;
    [SerializeField] private TextMeshProUGUI outputText;

    [Header("Options")]
    [SerializeField] private List<GameObject> options;
    [SerializeField] private bool showOptions;

    [Header("Test")]
    [SerializeField] private int coroutineNum;

    [Header("Unused yet")]
    [SerializeField] private HUD hud;
    [SerializeField] private int level;
    [SerializeField] private HUD levelSelect;

    private void Awake()
    {
        options = GameObject.FindGameObjectsWithTag("Option").ToList();
        if (options != null && options.Count > 0)
        {
            for (int i = 0; i < options.Count; i++)
            {
                options[i].name = (i + 1).ToString();

            }
        }
    }

    void Start()
    {
        SetTextAppearingSpeed();

        path = "S";
        //some statement
        if (true) 
        {
            SetText();
        }

        //hud = GetComponentInParent<HUD>();
        //Unused
        //levelSelect = 
        //level = LevelSelect.selectedLevel;
    }

    void Update()
    {
        SetTextAppearingSpeed();
        foreach (GameObject o in options)
        {
            if (showOptions)
            {
                o.SetActive(true);

            }
            else
            {
                o.SetActive(false);
            }
        }

    }

    public void SetTextAppearingSpeed()
    {
        letterDelay = GameData.letterDelay;
        Debug.Log(letterDelay);
        //letterDelay = letterDelay < 0 ? 0f : 0.02f;
    }

    public void SetOptionsActive(bool a)
    {
        foreach (GameObject o in options)
        {
            o.SetActive(a);
        }
    }

    private void SetText()
    {
        story = ReadStringToList(path);
        lineIndex = 0;
        //outputText.text = story[lineIndex];
    }

    public void Continue(string s = "")
    {
        if (animatingText) return;

        if (lineIndex + 1 >= story.Count)
        {
            //Some action to get back to Selection level or something
            SceneManager.LoadScene("LevelSelection");
            lineIndex = 0;
            return;
        }
        
        if (!showOptions)
        {
            ContinueNoOptions();
        }
        else if (s.Length > 0)
        {
            ContinueOptions(s);
        }
    }

    private void ContinueOptions(string s)
    {
        string tempPath = path;

        try
        {
            path += "." + s;
            SetText();

            showOptions = false;
            SetOptionsActive(showOptions);

            StopAllCoroutines();
            StartCoroutine(TypeSentence(story[lineIndex], outputText));
        }
        catch (System.Exception ex)
        {
            path = tempPath;
            Debug.Log(string.Format("<b>I'll let you continue, check code later!</b>\n<i>{0}</i>", ex.Message));
        }

        Debug.Log(path);
    }

    private void ContinueNoOptions()
    {
        outputText.text = "";

        //textAnimation.TypeSentence(text[++lineIndex], outputText);
        StartCoroutine(TypeSentence(story[++lineIndex], outputText));
        //outputText.text = text[++lineIndex];

    }
    public IEnumerator TypeSentence(string sentence, TextMeshProUGUI output)
    {

        animatingText = true;
        string[] array = sentence.Split(' ');
        yield return new WaitForSeconds(letterDelay);
        //output.text = array[0];
        output.text = "" + sentence[0];


        Debug.Log(string.Format("Sentence: {0}, amount of words: {1}", sentence, array.Length));

        for (int i = 1; i < sentence.Length; ++i)
        {
            yield return new WaitForSeconds(letterDelay);
            //if (output.text.Equals(""))
            //{
            //    output.text += array[i];

            //}
            //else
            //{
            //    output.text += " " + array[i];
            //}
            output.text += sentence[i];

        }
        animatingText = false;
    }

    private List<string> ReadStringToList(string path)
    {
        string file = "Assets/Stories/Chapter 1/" + path + ".txt";
        if (!File.Exists(file)) throw new System.Exception(string.Format
            ("Path <b><color=#C20000>{0}</color></b> is missing.", file));

        //Read the text from directly from the test.txt file
        var lines = File.ReadAllLines(file);
        foreach (string s in lines)
        {
            Debug.Log(s);
        }

        //Debug.Log(lines);

        return new List<string>(lines);
    }

    //Method to check for special words and booleans to show options or not, etc
    private void CheckLines()
    {
        //showOptions = ;
    }
}
