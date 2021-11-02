using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : SingletonMonoBehaviour<MyGameManager>,IGameManager
{
    public String MusicName { get; set; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
