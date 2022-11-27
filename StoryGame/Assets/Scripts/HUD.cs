using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Story story;
    [SerializeField] private GameObject storyObj;

    [SerializeField] private LevelSelect backButton;
    [SerializeField] private GameObject backButtonObj;

    // Start is called before the first frame update
    void Start()
    {
        if (storyObj != null)
        {
            story = storyObj.GetComponent<Story>();
        }

        if (backButtonObj != null)
        {
            backButton = backButtonObj.GetComponent<LevelSelect>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
