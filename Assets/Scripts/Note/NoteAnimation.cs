using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NoteAnimation : MonoBehaviour
{
    [Inject] private MusicManager _manager;

    [SerializeField] private GameObject sphereObj;

    private float _addScaleValue=0.02f;
   

    private float startTime;
    private float finishTime;
    private float AnimTime;
    
    private Transform _transform;

    private Vector3 scaleVec;

    private bool IsAnimating;
    // Start is called before the first frame update
    void Start()
    {
        _transform = sphereObj.transform;
        _transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.localScale = CurrentScaleVec3(CaluculateScale());
    }

    public void SetAnimTime(MusicManager _manager,float startTime,float finishTime)
    {
        this.startTime = startTime;
        this.finishTime = finishTime;
        AnimTime = finishTime - startTime;
        this._manager = _manager;
    }

    private float CaluculateScale()
    {
        float currentScale =  1 - ((finishTime - _manager.currentTime) / AnimTime);
        currentScale = currentScale >= 1 ? 1 : currentScale;

        return currentScale;
    }

    private Vector3 CurrentScaleVec3(float scale)
    {
        return new Vector3(scale,scale,scale);
    }
}
