using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private int levelId;

    [SerializeField] private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        if (levelId == 0)
        {
            textMesh.SetText("Back");

        }
        else
        {
            textMesh.SetText(levelId.ToString());

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScene()
    {
        if (levelId == 0)
        {
            SceneManager.LoadScene("LevelSelection");
        }
        else
        {
            SceneManager.LoadScene("Level " + levelId);

        }
    }
}
