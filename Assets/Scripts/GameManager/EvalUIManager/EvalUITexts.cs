using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EvalUITexts : MonoBehaviour
{
    public List<TextMeshProUGUI> Texts { get; private set; }
    // Start is called before the first frame update
    [SerializeField]
    private int objectNum;

    [SerializeField]
    private TextMeshProUGUI textPrefab;

    private int Currentusednum;
    private void Awake()
    {
        Texts = new List<TextMeshProUGUI>();
        for (int i = 0; i < objectNum; i++)
        {
            var textRep = Instantiate(textPrefab, this.transform);
            textRep.gameObject.SetActive(false);
            Texts.Add(textRep);
        }
    }

    public TextMeshProUGUI GetUseableText()
    {
        return Texts.FirstOrDefault(text => !text.gameObject.activeSelf);
    }
}
