using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    #region Variables
    [Header("Settings")]
    [SerializeField] int _maxAttraction = 5;

    private int _currentAttraction;
    private bool _inLove = false;

    #region Getters
    public int MaxAttraction => _maxAttraction;
    public int CurrentAttraction => _currentAttraction;
    #endregion

    #region Events
    public event System.Action AttractionUpdated;
    public event System.Action FellInLove;
    #endregion

    #endregion

    private void Awake()
    {
        _currentAttraction = 0;
    }

    public void IncreaseAttraction(int attractionAmount)
    {
        _currentAttraction += attractionAmount;
        AttractionUpdated?.Invoke();
    }

    public void DecreaseAttraction(int attractionAmount)
    {
        _currentAttraction -= attractionAmount;

        if (_currentAttraction < 0)
        {
            _currentAttraction = 0;
            FallInLove();
        }

        AttractionUpdated?.Invoke();
    }

    private void FallInLove()
    {
        FellInLove?.Invoke();
    }
}
