using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VSync : MonoBehaviour
{
    public Toggle toggleVS;
    public SaveSettings saveSettings;
    public void SetVSync()
    {
        QualitySettings.vSyncCount = toggleVS.isOn ? 1 : 0;
        saveSettings.data[5] = toggleVS.isOn.ToString();
    }
    private void Start()
    {
        toggleVS.isOn = (QualitySettings.vSyncCount == 1) ? true: false;
        saveSettings.data[5] = toggleVS.isOn.ToString();
    }
}
