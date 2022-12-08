using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chapter : MonoBehaviour
{
    [SerializeField] private Story story;
    [SerializeField] private HUD hud;

    [SerializeField] private string language;

    private Dictionary<string, TextAsset> ro;
    private Dictionary<string, TextAsset> en;
    private Dictionary<string, Dictionary<string, TextAsset>> storyByLanguage;

    [SerializeField] Audio audio;

    private void Awake()
    {
        language = GameData.currentLanguage;
        storyByLanguage = new Dictionary<string, Dictionary<string, TextAsset>>();

        ro = new Dictionary<string, TextAsset>();
        en = new Dictionary<string, TextAsset>();

        if (language.Equals("en"))
        {

            foreach (TextAsset v in Resources.LoadAll<TextAsset>("Stories/" + SceneManager.GetActiveScene().name + "/" + language))
            {
                en.Add(v.name, v);
            }

            if (!storyByLanguage.ContainsKey(language))
            {
                storyByLanguage.Add(language, en);
            }

        }
        else if (language.Equals("ro"))
        {
            foreach (TextAsset v in Resources.LoadAll<TextAsset>("Stories/" + SceneManager.GetActiveScene().name + "/" + language))
            {
                ro.Add(v.name, v);
            }
            if (!storyByLanguage.ContainsKey(language))
            {
                storyByLanguage.Add(language, ro);
            }
        }

        //foreach (KeyValuePair<string, TextAsset> entry in romanianDict)
        //{
        //    //Debug.Log("Hex: " + ConvertToHex(entry.Key) + ", path: " + entry.Key + ", length: " + entry.Key.Length);
        //}
        ////Debug.Log(romanianDict.Count);
    }

    void Start()
    {
        hud.SetStory(storyByLanguage[language]);
        audio.PlayStoryBackground();
    }

    void Update()
    {
        
    }
}
