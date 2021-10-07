using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(PlayerViewMove))]
[RequireComponent(typeof(PlayerSEPlayer))]
public class Player : MonoBehaviour
{
    public Camera fpsCam;

    private void Awake()
    {
        //fpsCam = GetComponent<Camera>();
    }
}
