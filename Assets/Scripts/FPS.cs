using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FPS : MonoBehaviour
{
    public Slider fpsSlider;
    public TMP_InputField fpsInputField;
    public SaveSettings saveSettings;
    public void SetSliderFPS()
    {
        Application.targetFrameRate = (int)fpsSlider.value * 5;
        fpsInputField.text = (fpsSlider.value * 5).ToString();
        saveSettings.data[4] = fpsSlider.value.ToString();
    }

    public void SetFieldFPS()
    {
        if (Convert.ToInt32(fpsInputField.text) / 5 < fpsSlider.minValue)
            fpsInputField.text = fpsSlider.minValue.ToString();
        else if (Convert.ToInt32(fpsInputField.text) / 5 > fpsSlider.maxValue)
            fpsInputField.text = fpsSlider.maxValue.ToString();
        Application.targetFrameRate = Convert.ToInt32(fpsInputField.text);
        fpsSlider.value = Convert.ToInt32(fpsInputField.text) / 5;
        saveSettings.data[4] = fpsSlider.value.ToString();
    }
    private void Start()
    {
        fpsSlider.value = 60;
        fpsInputField.text = "300";
        saveSettings.data[4] = fpsSlider.value.ToString();
    }


}
