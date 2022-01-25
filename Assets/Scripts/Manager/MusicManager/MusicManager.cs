using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameManager.MySceneManager;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class MusicManager : MonoBehaviour
{
    public float currentTime = 0;
    public bool isPlaying;

    private CancellationToken _token;
    
    private String musicclipfile = "Music/phony";
    public AudioSource _audioSource;
    private AudioClip _audio;
    private void Start()
    {
        _token = this.GetCancellationTokenOnDestroy();
        //Debug.Log(MyGameManager.Instance.MusicName);
        _audioSource = GetComponent<AudioSource>();
        _audio = (AudioClip)Resources.Load(musicclipfile);
        _audioSource.clip = _audio;
        OnPlay(_token).Forget();
        this.FixedUpdateAsObservable()
            .Subscribe(_ =>currentTime=_audioSource.time)
            .AddTo(this);
    }

    public async UniTaskVoid OnPlay(CancellationToken _token)
    {
        await UniTask.WaitUntil((() =>isPlaying), cancellationToken: _token);
        _audioSource.Play();
    }
}