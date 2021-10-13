using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PoolingNoteFactory : MonoBehaviour,INoteFactory
{
    [Inject] private MusicManager _manager;
    private List<SetNotesInfo> _currentNotesInfo;

    private BaseMusicData _data;
    
    private float _allowableError=0.01f;

    private int index=0;
    // Start is called before the first frame update
    public void StartInstanceNotes()
    {
        this.FixedUpdateAsObservable()
            .Subscribe(_ => InstanceNote())
            .AddTo(this);
    }

    public void InstanceNote()
    {
        for (int i=0;i<3;i++ )
        {
            if (Mathf.Abs(_manager.currentTime - _currentNotesInfo[i + index].Offset) > _allowableError)
            {
                _currentNotesInfo.RemoveAt(i+index);
                Debug.Log("Instance Note");
            }
                
        }
        
    }

    public void SetNotesInfo(List<SetNotesInfo> info,BaseMusicData data)
    {
        _currentNotesInfo = info;
        _data = data;
    }
}
