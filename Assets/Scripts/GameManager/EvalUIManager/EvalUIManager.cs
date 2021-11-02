using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager.EvalUIManager
{
    public class EvalUIManager : MonoBehaviour
    {
        [SerializeField]
        private EvalUITexts[] evalTexts;

        private Sequence sequence;
        private bool _isAnimating;
        
        CancellationToken _token;

        private Camera _camera;

        private void Awake()
        {
            _token = this.GetCancellationTokenOnDestroy();
            _camera = Camera.main;
            
        }


        public void StartAnim(Vector3 vec,NoteEval eval)
        {
            
            var _text = evalTexts[(int) eval].GetUseableText();
            var _transform = _text.gameObject.GetComponent<RectTransform>();
            
            _text.gameObject.SetActive(true);
            
            
            _isAnimating = true;
            
            this.FixedUpdateAsObservable()
                .TakeWhile(_ => _isAnimating)
                .Subscribe(_ =>
                {
                    Vector2 vec2 = RectTransformUtility.WorldToScreenPoint(_camera, vec);
                    _transform.position = vec2;
                });
            
            TextAnim(_transform,_text,_token).Forget();
        }

        private async UniTaskVoid TextAnim(RectTransform _transform,TextMeshProUGUI _text, CancellationToken token)
        {
            _transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            _transform.DOScale(0.7f, 0.5f).SetEase(Ease.OutElastic);
            _text.DOFade(1, 0.25f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.25f), cancellationToken: token);
            _text.DOFade(0, 0.25f).OnComplete((() =>
            {
                _isAnimating = false;
                _text.gameObject.SetActive(false);
            }));

        }
    }
}
