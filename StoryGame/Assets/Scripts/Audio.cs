using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource timer;
    [SerializeField] private AudioSource timerEnd;
    [SerializeField] private AudioSource menuBackground;
    [SerializeField] private AudioSource storyBackground;
    [SerializeField] private AudioSource button;

    private void Start()
    {

    }

    void Update()
    {
        timer.volume = PlayerPrefs.GetFloat("Background");
        timerEnd.volume = PlayerPrefs.GetFloat("Background");
        menuBackground.volume = PlayerPrefs.GetFloat("Background");
        storyBackground.volume = PlayerPrefs.GetFloat("Background");
        button.volume = PlayerPrefs.GetFloat("FX");
        //Debug.Log("Button volume " + button.volume);
    }

    public void PlayTimer()
    {
        timer.Play();
        Debug.Log("Timer Played");
    }
    public void PlayTimerEnd()
    {
        timerEnd.Play();
        Debug.Log("Timer End Played");
    }
    public void PlayMenuBackground()
    {
        menuBackground.Play();
        Debug.Log("Menu Played");
    }
    public void PlayStoryBackground()
    {
        storyBackground.Play();
        Debug.Log("Story Played");
    }
    public void PlayButton()
    {
        button.Play();
        Debug.Log("Button Played");
    }
}
