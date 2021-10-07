using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMusicData : MonoBehaviour
{
    public List<setValues> _valueses;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    [System.Serializable]
    public struct setValues
    {
        public GameObject gameObject;
        public float offset;

        public setValues(GameObject game,float offset)
        {
            this.gameObject = game;
            this.offset = offset;
        }
    }
}
