using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [Header("Load Level")]
    [SerializeField] private int level;
    //[SerializeField] private HUD hud;
    public static int selectedLevel;

    [SerializeField] private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        if (level == 0)
        {
            textMesh.SetText("Back");

        }
        else
        {
            textMesh.SetText(level.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLevelId()
    {
        return level;
    }

    public void OpenScene()
    {
        if (level == 0)
        {
            SceneManager.LoadScene("LevelSelection");
        }
        else
        {
            SceneManager.LoadScene("Level " + level);
        }
        selectedLevel = level;

    }

    public void ToLevelSelect()
    {

        SceneManager.LoadScene("LevelSelection");
        selectedLevel = 0;

    }
}
