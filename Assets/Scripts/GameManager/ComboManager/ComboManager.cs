using System.Collections;
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

    public int GetCombo()
    {
        return combo.combo;
    }
}
