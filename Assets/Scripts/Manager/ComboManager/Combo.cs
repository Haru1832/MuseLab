using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo
{
    private const int MaxCombo = 999;
    public int combo { get; private set; }

    public Combo()
    {
        combo = 0;
    }

    public void Add(int addValue)
    {
        combo += addValue;
        combo = Mathf.Min(combo, MaxCombo);
    }

    public void Reset()
    {
        combo = 0;
    }
}
