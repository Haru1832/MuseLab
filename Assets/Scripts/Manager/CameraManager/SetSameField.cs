using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SetSameField : MonoBehaviour
{
    public Camera Maincamera;
    private Camera MyCamera;
    

    private void Start()
    {
        Maincamera=Camera.main;
        MyCamera = GetComponent<Camera>();
        this.ObserveEveryValueChanged(x => x.Maincamera.fieldOfView)
            .Subscribe(x => MyCamera.fieldOfView = x)
            .AddTo(this);
    }
}
