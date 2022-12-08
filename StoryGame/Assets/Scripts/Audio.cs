using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource timer;
    [SerializeField] private AudioSource timerEnd;
    [SerializeField] private AudioSource menuBackground;
    [SerializeField] public static AudioSource menuBG;
    [SerializeField] private AudioSource storyBackground;
    [SerializeField] public static AudioSource storyBG;
    [SerializeField] private AudioSource button;

    private void Start()
    {

    }

    void Update()
    {
        timer.volume = PlayerPrefs.GetFloat("FX");
        timerEnd.volume = PlayerPrefs.GetFloat("FX");
        menuBackground.volume = PlayerPrefs.GetFloat("Background");
        //menuBG.volume = menuBackground.volume;
        storyBackground.volume = PlayerPrefs.GetFloat("Background");
        //storyBG.volume = storyBackground.volume;
        button.volume = PlayerPrefs.GetFloat("FX");
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
