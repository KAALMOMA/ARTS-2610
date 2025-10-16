using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UpdateVolume : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider volumeSlider;
    public string volumeParameter = "MasterVolume";
    void Start()
    {
        if (volumeSlider != null)
        {
            float savedVolume = PlayerPrefs.GetFloat(volumeParameter, 0.75f);
            volumeSlider.value = savedVolume;

            SetVolume(savedVolume);
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float sliderValue)
    {
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
        masterMixer.SetFloat(volumeParameter, dB);

        PlayerPrefs.SetFloat(volumeParameter, sliderValue);
    }
}
