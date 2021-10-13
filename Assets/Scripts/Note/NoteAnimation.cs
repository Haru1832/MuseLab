using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;

public class NoteAnimation : MonoBehaviour
{
    [Inject] private MusicManager _manager;

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

    public void SetAnimTime(MusicManager _manager,float startTime,float finishTime)
    {
        this.startTime = startTime;
        this.finishTime = finishTime;
        AnimTime = finishTime - startTime;
        this._manager = _manager;
        _isAnimating = true;
    }

    private float CaluculateScale()
    {
        float currentScale =  1 - ((finishTime - _manager.currentTime) / AnimTime);
        currentScale = currentScale >= 1 ? 1 : currentScale;
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
        gameObject.SetActive(false);
    }
}
