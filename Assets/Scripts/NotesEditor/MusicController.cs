using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioSource Source;

    public float _currentTime=0;
    // Start is called before the first frame update
    void Awake()
    {
        Source = GetComponent<AudioSource>();
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.G))
            .Subscribe(_ =>
            {
                if (Source.isPlaying)
                {
                    _currentTime = Source.time;
                    Source.Stop();
                    
                }
                else
                {
                    Source.time = _currentTime;
                    Source.Play();
                }
            })
            .AddTo(this);
    }
    
    public void Stop(){
        if (Source.isPlaying)
            Source.Stop();
    }
    
}
