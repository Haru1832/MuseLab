using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo
{
    private const int LimitCombo = 999;
    public int combo { get; private set; }
    public int maxCombo { get; private set; }

    public Combo()
    {
        maxCombo = 0;
        combo = 0;
    }

    public void Add(int addValue)
    {
        combo += addValue;
        combo = Mathf.Min(combo, LimitCombo);
    }

    public void Reset()
    {
        maxCombo = combo > maxCombo ? combo : maxCombo;
        combo = 0;
    }

    public void ResetMaxCombo()
    {
        maxCombo = 0;
    }
}
