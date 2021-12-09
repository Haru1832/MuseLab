using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameManager.MySceneManager;
using GameManager.MySceneManager;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TransitionButton : MonoBehaviour
{
    [SerializeField] private String Name; 
    
    [SerializeField] private bool isGameSceneTrans;
    
    [SerializeField]
    private MySceneManager _sceneManager;
    private Button button;

    [SerializeField] private Image panel;

    private SceneParameter _sceneParameter;
    // Start is called before the first frame update
    void Start()
    {
        //_sceneParameter = new SceneParameter("Sample");
        button = GetComponent<Button>();
        button.OnClickAsObservable()
            .Subscribe(_ => { panel.DOFade(1, 1).OnComplete(TransitionScene); })
            .AddTo(this);
    }

    private void TransitionScene()
    {
        Debug.Log("push");
        if (isGameSceneTrans) 
            TransitionGameScene();
        else
            TransitionSimpleScene();

    }

    private void TransitionGameScene()
    {
        _sceneManager.TransitionGameScene(Name);
    }
    
    private void TransitionSimpleScene()
    {
        _sceneManager.TransitionScene(Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
