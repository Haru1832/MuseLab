using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class NormalNoteFactory : MonoBehaviour,INoteFactory
{
    [Inject] private MusicManager _manager;
    private List<SetNotesInfo> _currentNotesInfo;
    private List<SetNotesInfo> _usedNotesInfo=new List<SetNotesInfo>();

    private float _allowableError=0.015f;

    private int index=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInstanceNotes()
    {
        this.FixedUpdateAsObservable()
            .Subscribe(_ => InstanceNote())
            .AddTo(this);
    }

    public void InstanceNote()
    {
        // for (int i=0;i<3;i++ )
        // {
        //     if (Mathf.Abs(_manager.currentTime - _currentNotesInfo[i + index].Offset) < _allowableError)
        //     {
        //         //_currentNotesInfo.RemoveAt(i+index);
        //         Debug.Log(_manager.currentTime);
        //         index++;
        //     }
        // }

        foreach (var VARIABLE in _currentNotesInfo)
        {
            
             if (Mathf.Abs(_manager.currentTime - VARIABLE.Offset) < _allowableError && !IsSameNote(VARIABLE))
             {
                 _usedNotesInfo.Add(VARIABLE);
                 Debug.Log(_manager.currentTime);
             }
        }
        
        // if (Mathf.Abs(_manager.currentTime - _currentNotesInfo[index].Offset) < _allowableError)
        // {
        //     Debug.Log(_manager.currentTime);
        //     index++;
        // }
    }

    public bool IsSameNote(SetNotesInfo info)
    {
        return _usedNotesInfo.Contains(info);
    }

    public void SetNotesInfo(List<SetNotesInfo> info)
    {
        _currentNotesInfo = info;
    }
}
