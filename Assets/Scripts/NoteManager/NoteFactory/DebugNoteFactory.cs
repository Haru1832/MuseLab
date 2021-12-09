using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class DebugNoteFactory : MonoBehaviour,INoteFactory
{
    [SerializeField]
    private MusicController _controller;
    private List<SetNotesInfo> _currentNotesInfo;

    private CancellationToken _token;

    private int index=0;

    private BaseMusicData _data;

    private float _animTime=1;

    private void Awake()
    {
        _token = this.GetCancellationTokenOnDestroy();
    }

    public void StartInstanceNotes()
    {
        this.FixedUpdateAsObservable()
            .Subscribe(_ => InstanceNote())
            .AddTo(this);
    }

    public void InstanceNote()
    {
        foreach (var VARIABLE in _currentNotesInfo)
        {
            if ( VARIABLE.Offset - _controller.Source.time  <= _animTime)
            {
                
                //Debug.Log(_controller.Source.time);
                if (!_data.notes[VARIABLE.NoteNumber - 1].activeSelf)
                {
                    GameObject noteObj = _data.notes[VARIABLE.NoteNumber - 1];
                    noteObj.SetActive(true);
                    noteObj.transform.localScale = CurrentScaleVec3(CaluculateScale(_controller.Source.time,VARIABLE.Offset));
                    //WaitNoteActiveFalse(VARIABLE.Offset, _controller.Source.time, _animTime, _token).Forget();
                }
            }
        }
    }

    // private async UniTaskVoid WaitNoteActiveFalse(float startTime,float finishTime,float AnimTime,CancellationToken _token)
    // {
    //     await UniTask.WaitUntil((() => CaluculateScale(startTime, finishTime, AnimTime) >= 1), cancellationToken: _token);
    // }
    //

    public void SetNotesInfo(List<SetNotesInfo> info,BaseMusicData data)
    {
        _currentNotesInfo = info;
        _data = data;
    }
    
    private float CaluculateScale(float currentTime,float finishTime)
    {
        float currentScale = 0;
        currentScale = ((currentTime-(finishTime-_animTime) )/ _animTime);
        //currentScale = currentScale >= 1 ? 1 : currentScale;++
        if (currentScale >= 1)
        {
            gameObject.SetActive(false);
            currentScale = 1;
        }
        return currentScale;
    }
    
    private Vector3 CurrentScaleVec3(float scale)
    {
        return new Vector3(scale,scale,scale);
    }
}