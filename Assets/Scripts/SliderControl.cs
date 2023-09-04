using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1f;
    }

    public void SliderValue(float maxValue, float currentValue)
    {
        float sliderValue = maxValue - currentValue;
        slider.maxValue = maxValue;
        slider.value = sliderValue;
    }

}
