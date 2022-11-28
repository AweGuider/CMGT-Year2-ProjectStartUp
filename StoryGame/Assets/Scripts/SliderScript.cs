using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private SliderScript slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    void Start()
    {
        //slider.maxValue
    }

    public void ChangeLetterDelay(float value)
    {
        GameData.letterDelay = value;
        _sliderText.text = value.ToString();
    }
}
