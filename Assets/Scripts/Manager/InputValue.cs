using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InputValue : MonoBehaviour
{
    [Inject] private Config _config;
    private InputField _input;

    private void Start()
    {
        _input = GetComponent<InputField>();
    }


    public void SetSensitivity()
    {
        float i = Convert.ToSingle(_input.text);
        i = Mathf.Clamp(i, _config.LimitSensitivty[0], _config.LimitSensitivty[1]);
        _input.text = i.ToString();
        _config.view.Sensitivity = i;
    }

    public void SetFieldOfView()
    {
        int i = Convert.ToInt32(_input.text);
        i = Mathf.Clamp(i, _config.LimitFieldOfView[0], _config.LimitFieldOfView[1]);
        _input.text = i.ToString();
        _config.view.FieldOfView = i;
    }
}
