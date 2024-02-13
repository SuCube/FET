using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider slider;
    public SaveSettings saveSettings;
    public AudioClip clip;
    public AudioSource audio;

    public void SPACE()
    {
        audio.volume = slider.value;
        saveSettings.data[0] = slider.value.ToString();
    }

    private void Start()
    {
        slider.value = 1;
        saveSettings.data[0] = slider.value.ToString();
    }
    public void PlaySound()
    {
        audio.PlayOneShot(clip);
    }
}