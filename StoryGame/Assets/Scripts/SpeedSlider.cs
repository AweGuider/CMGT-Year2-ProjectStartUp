using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    [SerializeField] private float slowSpeed = 0.21f;
    [SerializeField] private float slowMediumSpeed = 0.14f;
    [SerializeField] private float fastMediumSpeed2 = 0.07f;
    [SerializeField] private float fastSpeed = 0f;

    private void Start()
    {
        slowSpeed = 0.21f;
        slowMediumSpeed = 0.14f;
        fastMediumSpeed2 = 0.07f;
        fastSpeed = 0f;
    }

    public void ChangeLetterDelay(float value)
    {
        Debug.Log(string.Format("Medium: {0}", value <= slowMediumSpeed && value >= fastMediumSpeed2));
        GameData.letterDelay = value;
        if (value <= slowSpeed && value > slowMediumSpeed)
        {
            _sliderText.text = "Slow";

        }
        else if (value <= slowMediumSpeed && value >= fastMediumSpeed2)
        {
            _sliderText.text = "Medium";

        }
        else if (value < fastMediumSpeed2 && value >= fastSpeed)
        {
            _sliderText.text = "Fast";

        }
    }
}
