using System;
using System.Collections;
using System.Collections.Generic;
using GameManager.SceneManager;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class MusicManager : MonoBehaviour
{
    public float currentTime = 0;
    [Inject(Id = "MusicName")] private String _musicName;

    private String musicclipfile = "Music/Determination";
    private AudioSource _audioSource;
    private AudioClip _audio;
    private void Start()
    {
        Debug.Log(_musicName);
        _audioSource = GetComponent<AudioSource>();
        _audio = (AudioClip)Resources.Load(musicclipfile);
        _audioSource.clip = _audio;
        OnPlay();
        this.FixedUpdateAsObservable()
            .Subscribe(_ =>currentTime=_audioSource.time)
            .AddTo(this);
    }

    public void OnPlay()
    {
        _audioSource.Play();
    }
}
