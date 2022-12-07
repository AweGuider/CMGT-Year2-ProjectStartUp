using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Sprite currentBackground;
    [SerializeField] private List<Sprite> backgrounds = new List<Sprite>();

    private void Awake()
    {
        if (currentBackground == null)
        {
            backgroundImage.sprite = currentBackground = backgrounds[0];
        }
    }

    public void ChangeBackground(int index)
    {
        backgroundImage.sprite = currentBackground = backgrounds[index];
    }
}
