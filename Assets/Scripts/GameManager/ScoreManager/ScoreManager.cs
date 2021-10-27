using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ScoreManager : MonoBehaviour
{

    [Inject] private ComboManager _comboManager;
    private Score score = new Score();
    

    public void AddScore(NoteEval noteEval)
    {
        int addValue=0;

        addValue = ScoreEvalValue[noteEval];
        if (noteEval == NoteEval.Bad || noteEval == NoteEval.Good)
        {
            _comboManager.ResetCombo();
        }
        else
        {
            _comboManager.AddCombo();
        }
        score.Add(addValue);
    }

    public int GetScore()
    {
        return score.score;
    }
    
    public int GetAddScore()
    {
        return score.Addscore;
    }

    public bool GetIsAddScore()
    {
        bool isAddscore = score.IsAddScore;
        score.IsAddScore = false;
        return isAddscore;
    }
    
    public void Reset()
    {
        score.Reset();
    }

    private Dictionary<NoteEval, int> ScoreEvalValue = new Dictionary<NoteEval, int>()
    {
        {NoteEval.Bad, 0},
        {NoteEval.Good, 1000},
        {NoteEval.Great, 3000},
        {NoteEval.Perfect, 5000},
    };
}
