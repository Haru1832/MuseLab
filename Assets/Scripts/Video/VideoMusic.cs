using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

public class VideoMusic : MonoBehaviour
{
    [Inject] private MusicManager _musicManager;
    
    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;
    private CancellationToken _token;
   [SerializeField] private Material _material;
    
    // [SerializeField]
    // private GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        //obj.SetActive(true);
        _videoPlayer = GetComponent<VideoPlayer>();
        _token = this.GetCancellationTokenOnDestroy();
        WaitStartMusic(_token).Forget();
        _material.color = Color.black;
    }

    private async UniTaskVoid WaitStartMusic(CancellationToken _token)
    {
        await UniTask.WaitUntil((() => _musicManager.isPlaying), cancellationToken: _token);
        VideoStart();
        
    }

    private void VideoStart()
    {
        _videoPlayer.Play();
        //obj.SetActive(false);
        _material.DOColor(Color.white, 1);
        this.ObserveEveryValueChanged(x => x._musicManager.currentTime)
            .Subscribe(x => _videoPlayer.time = x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
