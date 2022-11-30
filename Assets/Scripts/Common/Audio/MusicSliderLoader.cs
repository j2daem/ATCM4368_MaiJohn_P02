using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderLoader : MonoBehaviour
{
    private Slider _slider;
    private AudioManager _audioManager;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _audioManager = FindObjectOfType<AudioManager>();

        _slider.value = _audioManager.MusicVolume;
        _audioManager.ReassignMusicSlider(_slider);

        _slider.onValueChanged.AddListener(delegate { _audioManager.AdjustMusicVolume(); });
    }
}
