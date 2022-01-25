using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnlockMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
