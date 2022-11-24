using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] string mini;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseOption()
    {
        if (mini == null)
        {
            Continue();
        }
        else
        {
            PlayMiniGame();
        }
    }

    private void Continue()
    {
        throw new NotImplementedException();
    }

    public void PlayMiniGame()
    {

    }
}
