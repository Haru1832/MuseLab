using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTouch : MonoBehaviour,IApplyTouch
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyTouch()
    {
        Destroy(gameObject);
    }
}
