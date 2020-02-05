using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volumeSlider;
    public AudioSource audioSrc;


    public void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
    }
    public void SetVolume()
    {
        audioSrc.volume = volumeSlider.value;

    }
}
