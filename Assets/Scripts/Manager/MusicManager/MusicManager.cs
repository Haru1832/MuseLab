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
    [SerializeField]
    private float volume;

    private CancellationToken _token;
    
    private String musicclipfile = "Music/phony";
    public AudioSource _audioSource;
    private AudioClip _audio;

    public void ResetTime()
    {
        currentTime = 0;
        isPlaying = false;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.time = 0;
        _audioSource.Stop();
        _audioSource.volume = volume;
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _token = this.GetCancellationTokenOnDestroy();
        //Debug.Log(MyGameManager.Instance.MusicName);
        
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