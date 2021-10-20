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

    private float _allowableError=0.011f;

    private int index=0;

    private BaseMusicData _data;

    private float _animTime=1;
    
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
            if (Mathf.Abs(_manager.currentTime - VARIABLE.Offset) - _animTime < _allowableError && !IsSameNote(VARIABLE))
            {
                
                 _usedNotesInfo.Add(VARIABLE);
                 Debug.Log(_manager.currentTime);
                 if (!_data.notes[VARIABLE.NoteNumber - 1].activeSelf)
                 {
                     GameObject noteObj = _data.notes[VARIABLE.NoteNumber - 1];
                     
                     noteObj.SetActive(true);
                     Note note = noteObj.GetComponent<Note>();
                     note.SetAnimTime(_manager,_manager.currentTime,VARIABLE.Offset);
                     NoteAnimation _noteAnimation = noteObj.GetComponent<NoteAnimation>();
                     _noteAnimation.StartAnim(_manager,_manager.currentTime,VARIABLE.Offset);
                 }
            }
        }
    }

    public bool IsSameNote(SetNotesInfo info)
    {
        return _usedNotesInfo.Contains(info);
    }

    public void SetNotesInfo(List<SetNotesInfo> info,BaseMusicData data)
    {
        _currentNotesInfo = info;
        _data = data;
    }
}