using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{

    private AsyncOperation asyncLoad;
    [SerializeField]
    private Slider _slider;

    void Start()
    { // ロード画面の表示
        StartCoroutine(LoadScene());                    // 非同期ロードの開始
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);
        asyncLoad = SceneManager.LoadSceneAsync("Game");     // 次のシーンの非同期ロード開始
        asyncLoad.allowSceneActivation = false; // シーン遷移無効化

        // this.ObserveEveryValueChanged(x => x.asyncLoad.progress)
        //     .Subscribe(x =>
        //     {
        //        
        //     })
        //     .AddTo(this);
        
        DOTween.To(
            () => _slider.value,
            (value) => _slider.value = value,
            1,
            2
        );

        while (asyncLoad.progress < 0.9f)               // ロードが完了するまで 3 秒待機を繰り返す
        {
            
            yield return new WaitForSeconds(5f);
        }
        asyncLoad.allowSceneActivation = true;   

        //DisplayNext();                                  // ロード完了したら次の画面を表示
    }

    private void SceneTransition()
    {
        asyncLoad.allowSceneActivation = true;          // シーン遷移有効化
    }

    private void DisplayLoading()
    {
        // ロード画面の描画
    }

    private void DisplayNext()
    {
        // ロード完了後画面の描画
    }
}
