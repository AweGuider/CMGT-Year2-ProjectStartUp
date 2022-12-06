using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ForTesting : MonoBehaviour
{
    [Header("Are we testing?")]
    [SerializeField] private bool testing;

    [Header("Are we testing?")]
    [SerializeField] private HUD hud;
    [SerializeField] private ButtonInfo levelData;
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private Option option;
    [SerializeField] private SpeedSlider sliderScript;
    [SerializeField] private Story story;


    public void ToggleTest()
    {
        testing = !testing;
        string d;
        if (testing)
        {
            ClearLog();
            d = string.Format("<color=#00E900><b>TESTING</b></color>");
        }
        else
        {

            d = string.Format("<color=#E92700><b>NOT TESTING</b></color>");
        }
        
        Debug.Log(d);
    }

    public void ClearLog()
    {
        //var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        //var type = assembly.GetType("UnityEditor.LogEntries");
        //var method = type.GetMethod("Clear");
        //method.Invoke(new object(), null);
    }


    public void MainTest()
    {
        if (testing) return;
        string path = "To_the_kitchen";
        var options = new List<string>();
        //string linkPathName;
        string file = "Assets/Stories/Chapter 1/" + path + ".txt";

        //Read the text from directly from the test.txt file
        var lines = File.ReadAllLines(file).Where(s => s != "");
        foreach (string s in lines)
        {
            if (s.Contains('['))
            {
                s.Replace("[", "").Replace("]", "");
                if (s.Contains(','))
                {
                    var o = s.Split(",")[1];
                    options.Add(o);
                    Debug.Log(string.Format("Option message: {0}, number: {1}", o, options.IndexOf(o)));
                }

            }

        }
        //Debug.Log(lines);

    }
}
