using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelection");

    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("LevelSelection");

    }
    public void QuitGame()
    {
        SceneManager.LoadScene("LevelSelection");

    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("LevelSelection");

    }

    public void SS()
    {
        SceneManager.LoadScene("LevelSelection");

    }


    public virtual void LoadScene()
    {
        SceneManager.LoadScene("");
    }
}
