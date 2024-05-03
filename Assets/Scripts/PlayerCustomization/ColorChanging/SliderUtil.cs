using UnityEngine.UI;
using UnityEngine;

public class SliderUtil : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text ValueText;

    [SerializeField] private Color FullColor;

    [SerializeField] private string SaveValue;

    private void Start()
    {
        float savedValue = PlayerPrefs.GetFloat(SaveValue, 0);
        GetComponent<Slider>().SetValueWithoutNotify(savedValue);
        SetValue(savedValue);
    }

    public void SetValue(float value)
    {
        ValueText.text = $"{(value*100):f0}%";

        PlayerPrefs.SetFloat(SaveValue, value);

        ValueText.color = Color.Lerp(Color.black, FullColor, value / GetComponent<Slider>().maxValue);
    }
}
