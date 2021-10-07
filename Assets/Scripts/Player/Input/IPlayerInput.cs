using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    bool PushedShot { get; }
    bool PushedPause { get; }
    float InputX { get;}
    float InputY { get;}
}
