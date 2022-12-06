using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("Load Level")]
    [SerializeField] private int level;

    [SerializeField] private TextMeshProUGUI textMesh;

    void Start()
    {

        //if (level == 0)
        //{
        //    textMesh.SetText("Back");

        //}
        //else
        //{
        //    textMesh.SetText(level.ToString());
        //}
    }

     /* 
     * Load level/chapter
     */
    public void LoadChapter()
    {
        string scene = "";
        if (level == 0)
        {
            scene = "LevelSelection";
        }
        else
        {
            scene = "Chapter " + level;
        }

        if (scene != null && scene.Length > 0)
        {
            GameData.transition.StartTransition(scene);
        }
    }

     /*
     * Start game from main menu/open level selection
     */
    public void LoadSelection()
    {
        StartTransition("LevelSelection");
    }

    /* 
     * Open settings screen from main menu
     */
    public void OpenSettings()
    {
        

    }

    /* 
     * Quit game from main menu
     */
    public void QuitGame()
    {
        Debug.Log("QUIT SUCCESSFUL!");
        Application.Quit();
    }

    /* 
     * Open same screen menu
     */
    public void OpenMenu()
    {

    }

    /* 
     * Method for level transitions
     */
    private void StartTransition(string name)
    {
        GameData.transition.StartTransition(name);

    }

    /* 
    * Method for UI/element animations
    */
    private void StartAnimation()
    {

    }
}
