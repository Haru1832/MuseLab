using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ComboText : MonoBehaviour
{
    [Inject]
    private ComboManager _comboManager;

    [SerializeField]
    private TextMeshProUGUI comboText;
    
    [SerializeField]
    private TextMeshProUGUI comboBackText;
    
    private Sequence sequence;

    private RectTransform _transform;
    
    private RectTransform _Backtransform;
    
    // Start is called before the first frame update
    void Start()
    {
        _transform = comboText.GetComponent<RectTransform>();
        _Backtransform = comboBackText.GetComponent<RectTransform>();
                     TextAnim();

        this.ObserveEveryValueChanged(x => x._comboManager.GetCombo())
            .Subscribe(x =>
            {
                comboText.text = x.ToString();
                comboBackText.text = x.ToString();
                if(x!=0)
                    sequence.Restart();
            })
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void TextAnim()
    {

        sequence = DOTween.Sequence()
            .Append(_transform.DOScale(1.8f, 0.5f).SetEase(Ease.OutElastic))
            .Join(_Backtransform.DOScale(2.4f, 0.5f).SetEase(Ease.OutElastic))
            .Join(comboBackText.DOFade(0,0.5f))
            .Pause()
            .SetAutoKill(false)
            .SetLink(gameObject);

    }
}
