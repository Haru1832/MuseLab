using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private IPlayerInput _input;
    private Camera fpsCam;
    private Player _player;

    int layerMask = 1 << 8;

    private float range = 100f;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        fpsCam = _player.fpsCam;
        _input = GetComponent<IPlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => _input.PushedShot)
            .Subscribe(_ => Shoot())
            .AddTo(this);
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range,layerMask))
        {
            IApplyTouch _applyTouch;
            _applyTouch = hit.collider.gameObject.GetComponent<IApplyTouch>();
            
            _applyTouch.ApplyTouch();
        }
    }

    
}
