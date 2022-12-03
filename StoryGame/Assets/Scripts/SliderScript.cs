using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private SliderScript slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    [SerializeField] private float letterDelayMin;
    [SerializeField] private float letterDelayMax;

    void Start()
    {

        letterDelayMax = 0.2f;
        letterDelayMin = 0f;
    }

    public void ChangeLetterDelay(float value)
    {
        GameData.letterDelay = value;
        if (value <= letterDelayMax && value >= 0.1f)
        {
            _sliderText.text = "Slow";

        }
        else if (value < 0.1f && value >= letterDelayMin)
        {
            _sliderText.text = "Fast";

        }
    }
}
