using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FOV : MonoBehaviour
{
    public Slider fovSlider;
    public TMP_InputField fovInputField;
    public SaveSettings saveSettings;
    public void SetSliderFOV()
    {
        fovInputField.text = fovSlider.value.ToString();
        saveSettings.data[7] = fovInputField.text;
    }

    public void SetFieldFOV()
    {
        if (Convert.ToInt32(fovInputField.text) < fovSlider.minValue)
            fovInputField.text = fovSlider.minValue.ToString();
        else if (Convert.ToInt32(fovInputField.text) > fovSlider.maxValue)
            fovInputField.text = fovSlider.maxValue.ToString();
        fovSlider.value = Convert.ToInt32(fovInputField.text);
        saveSettings.data[7] = fovInputField.text;
    }
    private void Start()
    {
        fovSlider.value = 60;
        fovInputField.text = "60";
        saveSettings.data[7] = fovInputField.text;
    }
}
