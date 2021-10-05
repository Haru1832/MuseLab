using System.Collections.Generic;
using UnityEngine;

namespace musicEditor
{
    public class testEditor : MonoBehaviour
    {
        [SerializeField] private BaseMusicData _data;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _data._valueses.Add(new BaseMusicData.setValues(null,1));
            }
        }
    }

    
}