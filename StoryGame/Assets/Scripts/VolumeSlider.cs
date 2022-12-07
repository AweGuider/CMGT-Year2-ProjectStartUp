using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    [SerializeField] private bool FX;
    [SerializeField] private bool background;


    public void ChangeVolume()
    {
        float value = slider.value;
        if (FX)
        {
            PlayerPrefs.SetFloat("FX", value);
        }
        else if (background)
        {
            PlayerPrefs.SetFloat("Background", value);
        }

        _sliderText.text = string.Format("{0}%", Mathf.Round(value * 100f));
    }
}
