using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sensa : MonoBehaviour
{
    public Slider sensitivitySlider;
    public TMP_InputField sensitivityInputField;
    public SaveSettings saveSettings;
    public void SetSliderFOV()
    {
        sensitivityInputField.text = sensitivitySlider.value.ToString();
        saveSettings.data[6] = sensitivityInputField.text;
    }

    public void SetFieldFOV()
    {
        if (Convert.ToInt32(sensitivityInputField.text) < sensitivitySlider.minValue)
            sensitivityInputField.text = sensitivitySlider.minValue.ToString();
        else if (Convert.ToInt32(sensitivityInputField.text) > sensitivitySlider.maxValue)
            sensitivityInputField.text = sensitivitySlider.maxValue.ToString();
        sensitivitySlider.value = Convert.ToInt32(sensitivityInputField.text);
        saveSettings.data[6] = sensitivityInputField.text;
    }
    private void Start()
    {
        sensitivitySlider.value = 400;
        sensitivityInputField.text = "400";
        saveSettings.data[6] = sensitivityInputField.text;
    }
}
