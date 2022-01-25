using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameManager.ScoreManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResultScoreText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int currentScore = 0;
    private int _score;
    [Inject] private ScoreManager _scoreManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _score = _scoreManager.GetScore();
        
        DOTween.To(
                () => currentScore, 
                value => currentScore = value,
                _score, 
                2f)
            .OnUpdate(() => _text.text = string.Format($" {currentScore:D8}"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
