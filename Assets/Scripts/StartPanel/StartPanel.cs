using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPanel : MonoBehaviour
{
    [Inject] private MusicManager _musicManager;
    
    [SerializeField] private AudioSource audioSource;
    
    private CancellationToken _token;
    [SerializeField]
    private List<Image> images;
    
    [SerializeField]
    private List<Text> texts;
    
    [SerializeField]
    private List<TextMeshProUGUI> proTexts;
    

    private void Awake()
    {
        this.gameObject.SetActive(true);
        _token = this.GetCancellationTokenOnDestroy();
    }

    // Start is called before the first frame update
    void Start()
    {
        ControlStart(_token).Forget();
    }

    private async UniTaskVoid ControlStart(CancellationToken token)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
        float fadeOutTime = 2;
        audioSource.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(4), cancellationToken: token);
        foreach (var image in images)
        {
            image.DOFade(0, fadeOutTime);
        }
        foreach (var text in texts)
        {
            text.DOFade(0, fadeOutTime);
        }
        
        foreach (var text in proTexts)
        {
            text.DOFade(0, fadeOutTime);
        }
        await UniTask.Delay(TimeSpan.FromSeconds(fadeOutTime), cancellationToken: token);
        _musicManager.isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
