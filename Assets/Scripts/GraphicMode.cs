using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GraphicMode : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    public SaveSettings saveSettings;
    // Use this for initialization
    void Start()
    {
        dropDown.ClearOptions();
        dropDown.AddOptions(QualitySettings.names.ToList());
        dropDown.value = QualitySettings.GetQualityLevel();
        saveSettings.data[1] = dropDown.value.ToString();
    }

    public void SetQuaLity()
    {
        QualitySettings.SetQualityLevel(dropDown.value);
        saveSettings.data[1] = dropDown.value.ToString();
    }
}
