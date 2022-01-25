using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameManager.MySceneManager;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResultTransition : MonoBehaviour
{
    private MySceneManager _manager;
    [Inject] private MusicManager _musicManager;
    [SerializeField]
    private Image panel;

    private bool IsFinish => _musicManager.currentTime >= transTime;
    
    [SerializeField]
    private float transTime;

    private void Awake()
    {
        _manager = GetComponent<MySceneManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.ObserveEveryValueChanged(x => x.IsFinish)
            .Where(x => x)
            .Subscribe(_ => transResult())
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void transResult()
    {
        int endValue=0;
        int TweenTime=1;

        DOTween.To
        (
            () => _musicManager._audioSource.volume,
            (x) => _musicManager._audioSource.volume = x,
            endValue,
            TweenTime
        );
        panel.DOFade(1, TweenTime).OnComplete(TransitionScene);
    }

    private void TransitionScene()
    {
        Debug.Log("Load Result");
        _manager.TransitionScene("Result");
    }
    
    
}
