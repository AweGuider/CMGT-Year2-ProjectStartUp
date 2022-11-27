using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    [SerializeField] float letterPause;

    [SerializeField] TextAnimation textAnimation;
    [SerializeField] private HUD hud;
    [SerializeField] private HUD levelSelect;
    [SerializeField] private int level;
    [SerializeField] private string path;
    [SerializeField] private List<string> text;
    [SerializeField] private int lineIndex;
    [SerializeField] private bool showText;
    [SerializeField] private List<Option> options;
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private bool showing;

    // Start is called before the first frame update
    void Start()
    {
        letterPause = letterPause < 0 ? 0f : 0.5f;
        path = "S";
        options = new List<Option>();
        //level = LevelSelect.selectedLevel;
        //some statement
        if (true) 
        {
            text = ReadStringToList(path);
            lineIndex = 0;
            outputText.text = text[lineIndex];
        }

        hud = GetComponentInParent<HUD>();
        //levelSelect = 
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

    private List<string> ReadStringToList(string path)
    {
        //if (file == 0) return new List<string>();

        string file = "Assets/Stories/Chapter 1/" + path + ".txt";

        //Read the text from directly from the test.txt file
        var lines = File.ReadAllLines(file);
        foreach (string s in text)
        {
            Debug.Log(s);
        }
        //Debug.Log(lines);
        return new List<string>(lines);
    }

    public void SetStory()
    {
        //text = ReadStringToList(0);
    }

    public void Continue()
    {
        if (showing) return;
        Debug.Log("Line index before click: " + lineIndex);
        if (lineIndex + 1 >= text.Count)
        {
            //Some action to get back to Selection level or something
            SceneManager.LoadScene("LevelSelection");
            lineIndex = 0;
            return;
        }
        
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
        outputText.text = "";

        //textAnimation.TypeSentence(text[++lineIndex], outputText);
        StartCoroutine(TypeSentence(text[++lineIndex], outputText));
        //outputText.text = text[++lineIndex];
        Debug.Log("Line index after click: " + lineIndex);
        Debug.Log("NO OPTIONS, JUST CONTINUE");

    }
    public IEnumerator TypeSentence(string sentence, TextMeshProUGUI output)
    {
        showing = true;
        string[] array = sentence.Split(' ');
        yield return new WaitForSeconds(letterPause);
        output.text = array[0];
        Debug.Log(string.Format("Sentence: {0}, amount of words: {1}", sentence, array.Length));

        for (int i = 0; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            output.text += " " + array[i];
        }
        showing = false;
    }
}
