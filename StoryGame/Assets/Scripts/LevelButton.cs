using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [Header("Load Level")]
    [SerializeField] private int level;

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
        string scene = "";
        if (level == 0)
        {
            scene = "LevelSelection";
        }
        else
        {
            scene = "Level " + level;
        }

        if (scene != null && scene.Length > 0)
        {
            GameData.transition.StartTransition(scene);
        }
    }

    public void ToLevelSelect()
    {
        GameData.transition.StartTransition("LevelSelection");
    }
}
