using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantObj : MonoBehaviour
{
    [SerializeField] private GameObject PrefabCube;

    private int instanceNums=3; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < instanceNums; i++)
        {
            Instantiate(PrefabCube);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
