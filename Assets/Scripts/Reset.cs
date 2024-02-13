using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public Slider sensitivitySlider;
    public Slider fovSlider;
    public Slider fpsSlider;
    public Slider slider;
    public TMP_InputField fovInputField;
    public TMP_InputField sensitivityInputField;
    public Toggle toggleVS;
    public TMP_InputField fpsInputField;
    public TMP_Dropdown resolutionDropdown;
    public Toggle FSToggle;
    public TMP_Dropdown QualityDropDown;

    public void ResetSettings()
    {
        sensitivitySlider.value = 400;
        fovSlider.value = 60;
        fpsSlider.value = 60;
        slider.value = 1;
        fovInputField.text = "60";
        sensitivityInputField.text = "400";
        toggleVS.isOn = false;
        fpsInputField.text = "300";
        resolutionDropdown.value = resolutionDropdown.options.Count - 1;
        FSToggle.isOn = true;
        QualityDropDown.value = QualityDropDown.options.Count - 1;
    }
}
