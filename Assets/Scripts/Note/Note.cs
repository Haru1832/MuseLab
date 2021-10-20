using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(NoteTouch))]
public abstract class Note : MonoBehaviour
{
    public MusicManager manager;
    public float startTime;
    public float finishTime;
    
    public void SetAnimTime(MusicManager manager,float startTime,float finishTime)
    {
        this.manager = manager;
        this.startTime = startTime;
        this.finishTime = finishTime;
    }
}
