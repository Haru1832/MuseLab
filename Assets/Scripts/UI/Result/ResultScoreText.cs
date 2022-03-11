using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameManager.ScoreManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResultScoreText : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    [SerializeField]
    private float tweenTime = 3;

    private CancellationToken _token;
    private TextMeshProUGUI _text;
    private int currentScore = 0;
    private int _score;
    [Inject] private ScoreManager _scoreManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _token = this.GetCancellationTokenOnDestroy();
        _text = GetComponent<TextMeshProUGUI>();
        _score = _scoreManager.GetScore();
        
        PlayScoreRoll(_token).Forget();
    }


    async UniTaskVoid PlayScoreRoll(CancellationToken token)
    {
        await UniTask.WaitUntil(() => audioSource.isPlaying, cancellationToken: token);
        DOTween.To(
                () => currentScore, 
                value => currentScore = value,
                _score, 
                tweenTime)
            .OnUpdate(() => _text.text = string.Format($" {currentScore:D8}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
