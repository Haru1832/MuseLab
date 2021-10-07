using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour,IPlayerInput
{
    public bool PushedShot=>Input.GetMouseButtonDown(0);
    public bool PushedPause=>false;
    public float InputX => Input.GetAxis("Mouse X");
    public float InputY => Input.GetAxis("Mouse Y");
}
