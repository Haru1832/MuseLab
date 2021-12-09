using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class PutTimingButton : MonoBehaviour
{
    private TimingEditor _editor;

    [SerializeField] private int num;
    
    private Button _button;

    private void Awake()
    {
        
    }

    private void Start()
    {
        GameObject gameObject = GameObject.Find("TimingEditor");
        _editor = gameObject.GetComponent<TimingEditor>();
        _button = GetComponent<Button>();
        _button.OnPointerDownAsObservable()
            .Subscribe(_=> _editor.AddData(num));
    }
}
