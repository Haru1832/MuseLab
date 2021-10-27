using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreText : MonoBehaviour
{
    [Inject]
    private ScoreManager _scoreManager;

    [SerializeField]
    private Text scoreText;
    
    [SerializeField]
    private GameObject addScoreObj;
    
    private Text addScoreText;

    private RectTransform _transform;

    private Sequence sequence;

    private int addScore;

    [SerializeField] private RectTransform[] animPos;
    
    //private Animator _animator;
    // private static readonly int ScoreAnimTrigger = Animator.StringToHash("ScoreAnimTrigger");


    // Start is called before the first frame update
    void Start()
    {
        _transform = addScoreObj.GetComponent<RectTransform>();
        addScoreText = addScoreObj.GetComponent<Text>();
        //_animator = addScoreObj.GetComponent<Animator>();
        
        var color = addScoreText.color;
        color.a = 0;
        addScoreText.color = color;
        _transform.anchoredPosition = animPos[0].anchoredPosition;
        TextAnim();
        
        this.ObserveEveryValueChanged(x => x._scoreManager.GetScore())
            .Subscribe(x => scoreText.text = x.ToString("D8"))
            .AddTo(this);
        
        this.ObserveEveryValueChanged(x => x._scoreManager.GetIsAddScore())
            .Where(x=>x)
            .Subscribe(_ =>
            {
                addScore = _scoreManager.GetAddScore();
                addScoreText.text = "+" + addScore.ToString();
                if (addScore != 0)
                {
                    sequence.Restart();
                    Debug.Log("ScoreAnim");
                }
            })
            .AddTo(this);
    }

    private void TextAnim()
    {

        sequence= DOTween.Sequence()
        .Append(_transform.DOAnchorPos(animPos[1].anchoredPosition, 0.5f))
        .Join(addScoreText.DOFade(1f, 0.5f))
        .Append(addScoreText.DOFade(0f, 0.25f))
        .Pause()
        .SetAutoKill(false)
        .SetLink(gameObject);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}