using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    [SerializeField] private Transition transitionObj;
    [SerializeField] public static Transition transition;

    [SerializeField] public static float letterDelay;

    [SerializeField] public static float textDelay;
    [SerializeField] public static string sceneName;

    public static Dictionary<string, List<string>> storiesFolder;

    public static List<Chapter> chapters;

    public static List<string> languageFolder;

    public static List<string> currentFolder;
    public static string currentLanguage;

    public static string language;
    public static List<TextAsset> romanian;
    public static Dictionary<string, TextAsset> romanianDict;

    private bool lPressed;
    private bool devPressed;
    public static bool devMode;

    private void Awake()
    {
        romanianDict = new Dictionary<string, TextAsset>();
        foreach (TextAsset v in Resources.LoadAll<TextAsset>("Stories/Chapter 1/ro"))
        {
            //romanian.Add(v);
            romanianDict.Add(v.name, v); ;
        }
    }

    void Start()
    {
        transition = transitionObj;

        //romanian = new List<TextAsset>();


        foreach (KeyValuePair<string, TextAsset> entry in romanianDict)
        {
            //Debug.Log("Hex: " + ConvertToHex(entry.Key) + ", path: " + entry.Key + ", length: " + entry.Key.Length);
        }
        //Debug.Log(romanianDict.Count);
    }

    void Update()
    {
        Inputs();
        if (!SceneManager.GetActiveScene().name.Equals(sceneName))
        {
            sceneName = SceneManager.GetActiveScene().name;
        }
    }

    public static string ConvertToHex(string p)
    {
        byte[] ba = Encoding.Default.GetBytes(p);
        var hexString = BitConverter.ToString(ba);
        hexString = hexString.Replace("-", "");
        return hexString;
    }

    private void Inputs()
    {
        if (!devPressed && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Space))
        {
            devPressed = true;
            devMode = !devMode;
            Debug.Log("Developer Mode: " + devMode);
        }
        if (devMode && !lPressed && Input.GetKeyDown(KeyCode.L))
        {
            lPressed = true;
            SceneManager.LoadScene("LevelSelection");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (devPressed)
        {
            devPressed = false;
        }

        if (lPressed)
        {
            lPressed = false;
        }
    }
}
