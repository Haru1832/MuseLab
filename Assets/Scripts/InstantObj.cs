using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantObj : MonoBehaviour
{
    [SerializeField] private GameObject PrefabCube;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(PrefabCube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
