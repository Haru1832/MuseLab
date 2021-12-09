using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private AudioSource _audio;

    [SerializeField]
    private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audio.PlayOneShot(clip);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
