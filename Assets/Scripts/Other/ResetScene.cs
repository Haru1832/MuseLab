using System;
using System.Collections;
using System.Collections.Generic;
using GameManager.ScoreManager;
using UnityEngine;
using Zenject;

public class ResetScene : MonoBehaviour
{
    [Inject] private ComboManager _comboManager;
    [Inject] private ScoreManager _scoreManager;
    [Inject] private MusicManager _musicManager;

    private void Awake()
    {
        _comboManager.ResetMaxCombo();
        _comboManager.ResetCombo();
        _scoreManager.Reset();
        _musicManager.ResetTime();
    }
}
