using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTouch : MonoBehaviour,IApplyTouch
{
    private Note note;
    // Start is called before the first frame update
    void Start()
    {
        note = GetComponent<Note>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyTouch()
    {
        AddScore();
       gameObject.SetActive(false);
    }

    void AddScore()
    {
        NoteEval noteEval = ScoreJudge();
        Debug.Log(noteEval);
        //ScoreManager.Addscore
    }

    NoteEval ScoreJudge()
    {
        float currentTime = note.manager.currentTime;
        Debug.Log(currentTime);
        float finishTime = note.finishTime;
        float startTime = note.startTime;
        float errorTime = Mathf.Abs(currentTime - finishTime);
        if (errorTime <= finishTime - startTime && errorTime >=NoteFloatEval.FloatEvals[(int) NoteEval.Bad].Timing)
        {
            return NoteEval.Bad;
        }
        else if (errorTime < NoteFloatEval.FloatEvals[(int) NoteEval.Bad].Timing && errorTime >= NoteFloatEval.FloatEvals[(int) NoteEval.Good].Timing)
        {
            return NoteEval.Bad;
        }
        else if (errorTime < NoteFloatEval.FloatEvals[(int) NoteEval.Good].Timing && errorTime >= NoteFloatEval.FloatEvals[(int) NoteEval.Great].Timing)
        {
            return NoteEval.Good;
        }
        else if (errorTime < NoteFloatEval.FloatEvals[(int) NoteEval.Great].Timing && errorTime >= NoteFloatEval.FloatEvals[(int) NoteEval.Perfect].Timing)
        {
            return NoteEval.Great;
        }
        else if (errorTime < NoteFloatEval.FloatEvals[(int) NoteEval.Perfect].Timing && errorTime >= 0)
        {
            return NoteEval.Perfect;
        }
        

        
        return NoteEval.Bad;
    }
    
}
