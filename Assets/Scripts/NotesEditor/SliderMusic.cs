using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusic : MonoBehaviour
{
    private AudioSource _source;

    private CancellationToken _token;

    [SerializeField]
    private MusicController _controller;

    private Slider _slider;

    private bool _isChanging;
    
    private float _musicLength;
    // Start is called before the first frame update
    void Start()
    {
        _token = this.GetCancellationTokenOnDestroy();
        _slider = GetComponent<Slider>();
        _musicLength = _controller.Source.clip.length;
        this.UpdateAsObservable()
            .Where(_=>!_isChanging)
            .Subscribe(_ => _slider.value = _controller.Source.time / _musicLength)
            .AddTo(this);
        
        this.UpdateAsObservable()
            .Where(_=>Math.Abs(Input.GetAxisRaw("Horizontal")) > 0)
            .Subscribe(_ =>
            {
                _slider.value +=Input.GetAxisRaw("Horizontal")*Time.deltaTime;
                if (!_isChanging)
                {
                    _isChanging = true;
                    WaitChangePlay(_token).Forget();
                }
                setMusicTime();
            })
            .AddTo(this);

        // this.ObserveEveryValueChanged(x=>x._controller.Source.time)
        //     .Subscribe(_=>)
    }

    private async UniTaskVoid WaitChangePlay(CancellationToken token)
    {
        await UniTask.WaitUntil(() => _controller.Source.isPlaying, cancellationToken: token);
        _isChanging = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMusicTime()
    {
        _controller._currentTime = _slider.value * _musicLength;
        _controller.Stop();
    }
    
}
