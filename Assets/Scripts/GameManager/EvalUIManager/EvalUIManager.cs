using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private TextMeshProUGUI[] evalTexts;

        private List<RectTransform> evalRects;
    
        private Sequence sequence;
        private bool _isAnimating;

        private RectTransform _transform;
        private TextMeshProUGUI _text;
        private RectTransform _canvasTransform;

        private Camera _camera;

        private void Awake()
        {
            _canvasTransform = GetComponent<RectTransform>();
            evalRects = new List<RectTransform>();
            _camera = Camera.main;
            
        }

        // Start is called before the first frame update
        void Start()
        {

            //TextAnim();
            foreach (var text in evalTexts)
            {
                evalRects.Add( text.gameObject.GetComponent<RectTransform>());
            }
            
            _transform = evalRects[0];
            _text = evalTexts[0];
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void StartAnim(Vector3 vec,NoteEval eval)
        {
            _transform = evalRects[(int) eval];
            _text = evalTexts[(int) eval];
            
            _text.gameObject.SetActive(true);
            
            
            _isAnimating = true;
            
            this.FixedUpdateAsObservable()
                .TakeWhile(_ => _isAnimating)
                .Subscribe(_ =>
                {
                    Vector2 vec2 = RectTransformUtility.WorldToScreenPoint(_camera, vec);
                    // var screenPos =RectTransformUtility.WorldToScreenPoint(null,vec);
                    // RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasTransform,screenPos,null,out var vec2);
                    _transform.position = vec2;
                });
            
            TextAnim();
            //sequence.Restart();
        }

        // private RectTransform GetTextEval(NoteEval noteEval)
        // {
        //     switch (noteEval)
        //     {
        //         case NoteEval.Bad: return evalRects[0];
        //         case NoteEval.Good: return evalRects[1];
        //         case NoteEval.Great: return evalRects[2];
        //         case NoteEval.Perfect: return evalRects[3];
        //         default: return null;
        //     }
        // }

        private async UniTaskVoid TextAnim()
        {
            _transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            _transform.DOScale(0.7f, 0.5f).SetEase(Ease.OutElastic);
            _text.DOFade(1, 0.25f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.25f));
            _text.DOFade(0, 0.25f).OnComplete(AnimateFalse);

            // sequence = DOTween.Sequence()
            //     .Append(_transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutElastic))
            //     .Join(_text.DOFade(0,0.5f))
            //     .Pause()
            //     .SetAutoKill(false)
            //     .OnComplete(AnimateFalse)
            //     .SetLink(gameObject);

        }

        private void AnimateFalse()
        {
            _isAnimating = false;
        }
    }
}
