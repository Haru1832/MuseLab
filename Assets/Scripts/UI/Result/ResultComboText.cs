using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ResultComboText : MonoBehaviour
{
    private TextMeshProUGUI maxcombotext;
    private int _maxCombo = 0;
    [Inject] private ComboManager _comboManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        maxcombotext = GetComponent<TextMeshProUGUI>();
        _maxCombo = _comboManager.GetMaxCombo();
        
        maxcombotext.text = _maxCombo.ToString();

    }
}
