using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoteFloatEval
{
    public static FloatEval[] FloatEvals= new FloatEval[4]
    {
        new FloatEval(NoteEval.Bad,0.5f),
        new FloatEval(NoteEval.Good,0.5f),
        new FloatEval(NoteEval.Great,0.4f),
        new FloatEval(NoteEval.Perfect,0.3f),
    };
}

public class FloatEval
{
    public NoteEval NoteEval;
    public float Timing;

    public FloatEval(NoteEval noteEval,float timing)
    {
        this.NoteEval = noteEval;
        this.Timing = timing;
    }
}