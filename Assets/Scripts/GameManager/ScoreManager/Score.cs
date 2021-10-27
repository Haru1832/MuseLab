using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private const int MaxScore = 999999;
    public int score { get; private set; }
    
    public int Addscore { get; private set; }
    
    public bool IsAddScore{ get; set; }

    public Score()
    {
        score = 0;
    }

    public void Add(int addValue)
    {
        IsAddScore = true;
        Addscore = addValue;
        score += addValue;
        score = Mathf.Min(score, MaxScore);
    }
    
    public void Reset()
    {
        score = 0;
    }
}
