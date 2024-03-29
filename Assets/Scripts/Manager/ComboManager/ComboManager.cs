﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    private Combo combo=new Combo();

    public void AddCombo()
    {
        combo.Add(1);
    }

    public void ResetCombo()
    {
        combo.Reset();
    }
    
    public void ResetMaxCombo()
    {
        combo.ResetMaxCombo();
    }

    public int GetCombo()
    {
        return combo.combo;
    }
    
    public int GetMaxCombo()
    {
        return combo.maxCombo;
    }
}
