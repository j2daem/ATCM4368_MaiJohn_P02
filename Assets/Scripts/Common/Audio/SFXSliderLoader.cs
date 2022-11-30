using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSliderLoader : MonoBehaviour
{
    private Slider _slider;
    private AudioManager _audioManager;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _audioManager = FindObjectOfType<AudioManager>();

        _slider.value = _audioManager.SFXVolume;
        _audioManager.ReassignSFXSlider(_slider);

        _slider.onValueChanged.AddListener(delegate { _audioManager.AdjustSFXVolume(); });
    }
}
