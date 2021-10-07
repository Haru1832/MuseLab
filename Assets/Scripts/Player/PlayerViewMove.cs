using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerViewMove : MonoBehaviour
{
    private IPlayerInput _input;
    float x, z;
    float speed = 0.1f;

    private Player _player;
    private Camera fpsCam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;
    
    bool cursorLock = true;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    private void Awake()
    {
        _player = GetComponent<Player>();
        fpsCam = _player.fpsCam;
        _input = GetComponent<IPlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = fpsCam.transform.localRotation;
        characterRot = transform.localRotation;

        this.UpdateAsObservable()
            .Subscribe(_ => { MoveView(); })
            .AddTo(this);
    }

    // Update is called once per frame
    void MoveView()
    {
        float xRot = _input.InputX * Ysensityvity;
        float yRot = _input.InputY * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        fpsCam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;
    }
    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX,minX,maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }


}