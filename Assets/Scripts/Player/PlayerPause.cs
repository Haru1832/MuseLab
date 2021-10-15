using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerPause : MonoBehaviour
{
    private IPlayerInput _input;
    private PlayerViewMove _view;

    [Inject]
    private Config _config;

    private void Start()
    {
        _input = GetComponent<IPlayerInput>();
        _view = GetComponent<PlayerViewMove>();

        this.UpdateAsObservable()
            .Where(_ => _input.PushedPause)
            .Subscribe(_ =>
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    _view.isPlaying = false;
                    _config.gameObject.SetActive(true);
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    _view.isPlaying = true;
                    _config.gameObject.SetActive(false);
                }
            })
            .AddTo(this);
    }
    
    
}
