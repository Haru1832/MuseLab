using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using DG.Tweening;
using GameManager.EvalUIManager;
using GameManager.ScoreManager;
using UniRx;
using UniRx.Triggers;

public class NoteAnimation : MonoBehaviour
{
    private EvalUIManager _evalUiManager;
    [Inject] private ScoreManager _scoreManager;
    
    private MusicManager _manager;

    private Note _note;

    [SerializeField] private GameObject sphereObj;

    private CancellationToken token;
    
    private float _disTime=0.15f;

    private float startTime;
    private float finishTime;
    private float AnimTime;
    
    private Transform _transform;

    private Vector3 scaleVec;

    private bool _isAnimating;

    private bool _isFinished;
    // Start is called before the first frame update
    void Start()
    {
        _note = GetComponent<Note>();
        _evalUiManager = GameObject.Find("EvalUIManager").GetComponent<EvalUIManager>();
        token = this.GetCancellationTokenOnDestroy();
        _transform = sphereObj.transform;
        _transform.localScale = Vector3.zero;

        this.UpdateAsObservable()
            .Where(_ => _isAnimating)
            .Subscribe(_ => { _transform.localScale = CurrentScaleVec3(CaluculateScale()); })
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnim(MusicManager manager,float startTime,float finishTime)
    {
        this.startTime = startTime;
        this.finishTime = finishTime;
        this._manager = manager;
        AnimTime = finishTime - startTime;
        _isAnimating = true;
    }

    private float CaluculateScale()
    {
        float currentScale =  1 - ((finishTime - _manager.currentTime) / AnimTime);
        //currentScale = currentScale >= 1 ? 1 : currentScale;
        if (currentScale >= 1)
        {
            _isAnimating = false;
            currentScale = 1;
            EasingActiveFalse(token);
        }

        return currentScale;
    }

    private Vector3 CurrentScaleVec3(float scale)
    {
        return new Vector3(scale,scale,scale);
    }

    private async void EasingActiveFalse(CancellationToken _token)
    {
        
        Tweener t = _transform.DOScale(
            Vector3.zero,
            _disTime
        ).SetEase(Ease.InSine).OnComplete(Activefalse);
        //await UniTask.WaitUntil(t.ToUniTask(cancellationToken : _token), cancellationToken: _token);
    }

    void Activefalse()
    {
        if (gameObject.activeSelf)
        {
            _scoreManager.AddScore(NoteEval.Bad);
            _evalUiManager.StartAnim(this.transform.position,NoteEval.Bad);
        }

        gameObject.SetActive(false);
    }
}
