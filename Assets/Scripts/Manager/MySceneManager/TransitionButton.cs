using System.Collections;
using System.Collections.Generic;
using GameManager.MySceneManager;
using GameManager.SceneManager;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TransitionButton : MonoBehaviour
{
    [SerializeField]
    private MySceneManager _sceneManager;
    private Button button;

    private SceneParameter _sceneParameter;
    // Start is called before the first frame update
    void Start()
    {
        //_sceneParameter = new SceneParameter("Sample");
        button = GetComponent<Button>();
        button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("push");
                _sceneManager.TransitionScene("Sample");
            })
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
