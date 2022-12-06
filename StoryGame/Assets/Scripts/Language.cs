using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] private string buttonLanguage;
    [SerializeField] private string currentLanguage = "en";
    // Start is called before the first frame update
    void Start()
    {
        buttonLanguage = gameObject.name.ToLowerInvariant();
        if (GameData.currentLanguage == null || GameData.currentLanguage.Length == 0)
        {
            GameData.currentLanguage = "en";
        }
    }

    private void Update()
    {
        if (!currentLanguage.Equals(GameData.currentLanguage))
        {
            currentLanguage = GameData.currentLanguage;
        }
    }

    public void SetLanguage()
    {
        GameData.currentLanguage = buttonLanguage;
    }
}
