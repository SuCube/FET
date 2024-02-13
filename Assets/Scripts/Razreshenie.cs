using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Razreshenie : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    Resolution[] res;
    public Toggle FSToggle;
    public SaveSettings saveSettings;
    string[] strRes;
    public void ToggleFullScreen()
    {
        Screen.fullScreen = FSToggle.isOn;
        saveSettings.data[3] = FSToggle.isOn.ToString();
    }
    void Start()
    {
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        strRes = new string[res.Length];
        for (int i = 0; i < res.Length; i++)
            strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
        // Dropdown
        strRes = strRes.Distinct().ToArray();
        dropdown.ClearOptions();
        dropdown.AddOptions(strRes.ToList());
        dropdown.value = res.Length - 1;
        //Set default resolution
        Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, FSToggle.isOn);
        FSToggle.isOn = Screen.fullScreen;
        saveSettings.data[2] = dropdown.value.ToString();
        saveSettings.data[3] = FSToggle.isOn.ToString();
    }
    public void SetRes()
    {
        Screen.SetResolution(Convert.ToInt32(strRes[dropdown.value].Split('x')[0]), Convert.ToInt32(strRes[dropdown.value].Split('x')[1]) , FSToggle.isOn);
        saveSettings.data[2] = dropdown.value.ToString();
    }
}
