using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ResetSingleton : MonoBehaviour
{
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        // _button = GetComponent<Button>();
        // _button.OnClickAsObservable()
        //     .Subscribe(_ =>
        //     {
        //         Destroy();
        //     })
        //     .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
